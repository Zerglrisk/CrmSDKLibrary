using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrmSdkLibrary.Dataverse.Services
{
    public class SitemapNode
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public List<PrivilegeDetail> Privileges { get; set; } = new List<PrivilegeDetail>();
        public List<SitemapNode> Children { get; set; } = new List<SitemapNode>();
        public int ComplexityScore { get; set; }
    }

    public class PrivilegeInfo
    {
        public string MenuTitle { get; set; }
        public string MenuPath { get; set; }
        public List<PrivilegeDetail> PrivilegeDetails { get; set; }
        public string PrivilegeDescription => string.Join(Environment.NewLine,
            PrivilegeDetails.Select(p => p.ToString()));
    }

    public class PrivilegeDetail
    {
        public string Entity { get; set; }  
        public List<string> Privileges { get; set; } = new List<string>();
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Entity))
                return string.Join(", ", Privileges);
            return $"{Entity}: {string.Join(", ", Privileges)}";
        }
    }

    public class AdaptiveSitemapParser
    {
        private readonly int _processorCount;
        private const int PARALLEL_COMPLEXITY_THRESHOLD = 1000;
        private const int MIN_NODES_PER_CORE = 2;

        public AdaptiveSitemapParser()
        {
            _processorCount = Environment.ProcessorCount;
        }

        public (SitemapNode Root, List<PrivilegeInfo> Privileges) ParseSitemap(string sitemapXml)
        {
            var doc = XDocument.Parse(sitemapXml);

            // 먼저 빠른 초기 스캔으로 복잡도 분석
            var complexity = AnalyzeComplexity(doc);

            // 분석 결과에 따라 적절한 파싱 방법 선택
            if (ShouldUseParallelProcessing(complexity))
            {
                return ParseSitemapParallel(doc);
            }

            return ParseSitemapSequential(doc);
        }

        private class ComplexityAnalysis
        {
            public int TotalNodes { get; set; }
            public int PrivilegeCount { get; set; }
            public int MaxDepth { get; set; }
            public int ComplexityScore { get; set; }
        }

        private ComplexityAnalysis AnalyzeComplexity(XDocument doc)
        {
            var analysis = new ComplexityAnalysis();
            var stack = new Stack<(XElement Element, int Depth)>();

            foreach (var area in doc.Root.Elements("Area"))
            {
                stack.Push((area, 1));
            }

            while (stack.Count > 0)
            {
                var (element, depth) = stack.Pop();
                analysis.TotalNodes++;
                analysis.MaxDepth = Math.Max(analysis.MaxDepth, depth);

                // 권한 개수 카운트
                var privileges = element.Element("Privilege");
                if (privileges != null)
                {
                    analysis.PrivilegeCount += privileges.Attributes().Count();
                }

                // 하위 요소들을 스택에 추가
                foreach (var child in element.Elements())
                {
                    stack.Push((child, depth + 1));
                }
            }

            // 복잡도 점수 계산
            analysis.ComplexityScore = analysis.TotalNodes *
                (analysis.PrivilegeCount + 1) *
                (analysis.MaxDepth + 1);

            return analysis;
        }

        private bool ShouldUseParallelProcessing(ComplexityAnalysis complexity)
        {
            return complexity.ComplexityScore > PARALLEL_COMPLEXITY_THRESHOLD &&
                   complexity.TotalNodes >= _processorCount * MIN_NODES_PER_CORE;
        }

        private (SitemapNode Root, List<PrivilegeInfo> Privileges) ParseSitemapSequential(XDocument doc)
        {
            var root = new SitemapNode { Title = "Root" };
            var privileges = new List<PrivilegeInfo>();
            var stack = new Stack<(XElement Element, SitemapNode Node, string Path)>();

            // Areas 처리
            foreach (var area in doc.Root.Elements("Area"))
            {
                var areaNode = new SitemapNode
                {
                    Id = area.Attribute("Id")?.Value,
                    Title = area.Attribute("Title")?.Value,
                    Url = area.Attribute("Url")?.Value
                };
                root.Children.Add(areaNode);

                foreach (var group in area.Elements("Group"))
                {
                    stack.Push((group, areaNode, areaNode.Title));
                }
            }

            while (stack.Count > 0)
            {
                var (element, parent, path) = stack.Pop();
                var node = new SitemapNode
                {
                    Id = element.Attribute("Id")?.Value,
                    Title = element.Attribute("Title")?.Value,
                    Url = element.Attribute("Url")?.Value
                };

                // 권한 처리
                var privilegeElements = element.Elements("Privilege");
                if (privilegeElements.Any())
                {
                    var privilegeDetails = new List<PrivilegeDetail>();
                    foreach (var privilege in privilegeElements)
                    {
                        var detail = new PrivilegeDetail
                        {
                            Entity = privilege.Attribute("Entity")?.Value,
                            Privileges = privilege.Attribute("Privilege")?.Value
                                ?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(p => p.Trim())
                                .ToList() ?? new List<string>()
                        };
                        privilegeDetails.Add(detail);
                    }

                    node.Privileges = privilegeDetails;

                    privileges.Add(new PrivilegeInfo
                    {
                        MenuTitle = node.Title,
                        MenuPath = path,
                        PrivilegeDetails = privilegeDetails
                    });
                }

                parent.Children.Add(node);

                // SubAreas 처리
                foreach (var subArea in element.Elements("SubArea"))
                {
                    stack.Push((subArea, node, $"{path} > {node.Title}"));
                }
            }

            return (root, privileges);
        }

        private (SitemapNode Root, List<PrivilegeInfo> Privileges) ParseSitemapParallel(XDocument doc)
        {
            var root = new SitemapNode { Title = "Root" };
            var privilegesBag = new ConcurrentBag<PrivilegeInfo>();

            // Areas는 순차적으로 처리 (최상위 레벨이므로)
            var areas = doc.Root.Elements("Area")
                .Select(area => new SitemapNode
                {
                    Id = area.Attribute("Id")?.Value,
                    Title = area.Attribute("Title")?.Value,
                    Url = area.Attribute("Url")?.Value
                }).ToList();

            root.Children.AddRange(areas);

            // Groups와 SubAreas는 병렬 처리
            Parallel.ForEach(
                doc.Root.Elements("Area"),
                new ParallelOptions { MaxDegreeOfParallelism = _processorCount },
                area =>
                {
                    var areaNode = areas.First(n => n.Id == area.Attribute("Id")?.Value);
                    var areaPath = areaNode.Title;

                    var groups = ProcessGroupsParallel(area, areaPath, privilegesBag);
                    lock (areaNode.Children)
                    {
                        areaNode.Children.AddRange(groups);
                    }
                });

            return (root, privilegesBag.ToList());
        }

        private List<SitemapNode> ProcessGroupsParallel(XElement area, string areaPath,
            ConcurrentBag<PrivilegeInfo> privileges)
        {
            var groups = new ConcurrentBag<SitemapNode>();

            Parallel.ForEach(area.Elements("Group"), group =>
            {
                var groupNode = new SitemapNode
                {
                    Id = group.Attribute("Id")?.Value,
                    Title = group.Attribute("Title")?.Value,
                    Url = group.Attribute("Url")?.Value
                };

                // SubAreas 처리
                foreach (var subArea in group.Elements("SubArea"))
                {
                    var subAreaNode = new SitemapNode
                    {
                        Id = subArea.Attribute("Id")?.Value,
                        Title = subArea.Attribute("Title")?.Value,
                        Url = subArea.Attribute("Url")?.Value
                    };

                    var privilegeElements = subArea.Elements("Privilege");
                    if (privilegeElements.Any())
                    {
                        var privilegeDetails = new List<PrivilegeDetail>();
                        foreach (var privilege in privilegeElements)
                        {
                            var detail = new PrivilegeDetail
                            {
                                Entity = privilege.Attribute("Entity")?.Value,
                                Privileges = privilege.Attribute("Privilege")?.Value
                                    ?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(p => p.Trim())
                                    .ToList() ?? new List<string>()
                            };
                            privilegeDetails.Add(detail);
                        }

                        subAreaNode.Privileges = privilegeDetails;

                        privileges.Add(new PrivilegeInfo
                        {
                            MenuTitle = subAreaNode.Title,
                            MenuPath = $"{areaPath} > {groupNode.Title}",
                            PrivilegeDetails = privilegeDetails
                        });
                    }

                    groupNode.Children.Add(subAreaNode);
                }

                groups.Add(groupNode);
            });

            return groups.ToList();
        }
    }
    public static class SitemapNodeExtensions
    {
        /// <summary>
        /// 권한이 있는 노드만 필터링하여 새로운 트리 구조를 반환합니다.
        /// </summary>
        public static SitemapNode FilterNodesWithPrivileges(this SitemapNode root)
        {
            // 루트 노드 복사
            var filteredRoot = new SitemapNode
            {
                Id = root.Id,
                Title = root.Title,
                Url = root.Url,
                Privileges = root.Privileges,
                ComplexityScore = root.ComplexityScore
            };

            // 자식 노드들 중 권한이 있는 노드들만 재귀적으로 필터링
            var filteredChildren = root.Children
                .Select(child => FilterNodesWithPrivilegesRecursive(child))
                .Where(node => node != null)
                .ToList();

            filteredRoot.Children = filteredChildren;

            // 루트를 반환할 때는 자식 노드가 하나라도 있거나 루트 자체에 권한이 있는 경우만 반환
            return filteredRoot.Children.Any() || filteredRoot.Privileges.Any()
                ? filteredRoot
                : null;
        }

        private static SitemapNode FilterNodesWithPrivilegesRecursive(SitemapNode node)
        {
            // 현재 노드에 권한이 있거나 자식 중에 권한이 있는 노드가 있는지 먼저 확인
            bool hasPrivilegesInSubtree = HasPrivilegesInSubtree(node);

            if (!hasPrivilegesInSubtree)
            {
                return null; // 권한이 없는 서브트리는 제외
            }

            // 현재 노드 복사
            var filteredNode = new SitemapNode
            {
                Id = node.Id,
                Title = node.Title,
                Url = node.Url,
                Privileges = node.Privileges,
                ComplexityScore = node.ComplexityScore
            };

            // 자식 노드들 재귀적으로 처리
            var filteredChildren = node.Children
                .Select(child => FilterNodesWithPrivilegesRecursive(child))
                .Where(child => child != null)
                .ToList();

            filteredNode.Children = filteredChildren;
            return filteredNode;
        }

        /// <summary>
        /// 해당 노드 또는 하위 노드들 중에 권한이 있는지 확인합니다.
        /// </summary>
        private static bool HasPrivilegesInSubtree(SitemapNode node)
        {
            if (node.Privileges.Any())
                return true;

            return node.Children.Any(child => HasPrivilegesInSubtree(child));
        }

        /// <summary>
        /// 권한이 있는 노드의 수를 반환합니다.
        /// </summary>
        public static int CountNodesWithPrivileges(this SitemapNode root)
        {
            int count = root.Privileges.Any() ? 1 : 0;
            count += root.Children.Sum(child => CountNodesWithPrivileges(child));
            return count;
        }

        /// <summary>
        /// 전체 권한 수를 반환합니다.
        /// </summary>
        public static int CountTotalPrivileges(this SitemapNode root)
        {
            int count = root.Privileges.Sum(p => p.Privileges.Count);
            count += root.Children.Sum(child => CountTotalPrivileges(child));
            return count;
        }
    }
}
