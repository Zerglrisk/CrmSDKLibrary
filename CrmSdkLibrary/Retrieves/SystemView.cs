﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;

namespace CrmSdkLibrary.Retrieves
{
    public class SystemView
    {
        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/web-api/savedquery?view=dynamics-ce-odata-9"/>
        /// <param name="service"></param>
        /// <param name="entityLogicalName"></param>
        /// <returns></returns>
        public static EntityCollection RetrieveViews(IOrganizationService service, string entityLogicalName)
        {
            try
            {
                var qe = new QueryExpression("savedquery")
                {
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression()
                    {
                        Conditions =
                        {
                            new ConditionExpression("returnedtypecode", ConditionOperator.Equal, Messages.GetEntityTypeCode(service ,entityLogicalName))
                        }
                    }
                };
                return service.RetrieveMultiple(qe);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve View(savedquery) Entity
        /// </summary>
        /// <param name="service"></param>
        /// <param name="viewId"></param>
        /// <returns></returns>
        public static Entity RetrieveView(IOrganizationService service, Guid viewId)
        {
            try
            {
                return service.Retrieve("savedquery", viewId, new ColumnSet(true));
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Retrieve Columns(Attributes) From View
        /// </summary>
        /// <param name="service"></param>
        /// <param name="viewId"></param>
        /// <param name="ordering"></param>
        /// <returns></returns>
        public static IEnumerable<string> RetrieveViewAttributeLogicalNames(IOrganizationService service, Guid viewId, bool useLayoutXml = false)
        {
            try
            {
                var view = RetrieveView(service, viewId);

                if (useLayoutXml)
                {
                    var xml = new XmlDocument();
                    xml.LoadXml(view["layoutxml"].ToString());
                    var xnList = xml.GetElementsByTagName("cell");

                    return (from XmlNode xn in xnList where xn.Attributes != null select xn.Attributes["name"].Value)
                        .ToList();
                }
                else
                {
                    if (view.Contains("fetchxml"))
                    {
                        var attributes = new List<string>();
                        var qe = Messages.FetchXmlToQueryExpression(service, view["fetchxml"].ToString());

                        //Get all LinkEntity's Attribute into Dictionary
                        foreach (var linkEntity in qe.LinkEntities)
                        {
                            attributes.AddRange(linkEntity.Columns.Columns.Select(attr => $"{linkEntity.EntityAlias}.{attr}"));

                            //Get all Next LinkEntity's Attribute into Dictionary
                            attributes.AddRange(GetLinkEntityLogicalNames(service, linkEntity.LinkEntities.ToList()));
                         
                        }

                        return attributes;
                    }
                    else
                    {
                        throw new Exception("Cannot find fetchxml string");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static IEnumerable<string> GetLinkEntityLogicalNames(IOrganizationService service, List<LinkEntity> linkEntities)
        {
            var attributes = new List<string>();

            foreach (var linkEntity in linkEntities)
            {
                attributes.AddRange(linkEntity.Columns.Columns.Select(attr => $"{linkEntity.EntityAlias}.{attr}"));

                //Get all Next LinkEntity's Attribute into Dictionary
                attributes.AddRange(GetLinkEntityLogicalNames(service, linkEntity.LinkEntities.ToList()));
            }

            return attributes;
        }


        /// <summary>
        /// Retrieve Columns(Attributes) From View as Dictionary(logical name, display name)
        /// </summary>
        /// <param name="service"></param>
        /// <param name="viewId"></param>
        /// <param name="ordering"></param>
        /// <returns></returns>
        public static Dictionary<string, string> RetrieveAttributes(IOrganizationService service, Guid viewId, bool useLayoutXml = false)
        {
            try
            {
                var view = RetrieveView(service, viewId);
                if (view.Contains("fetchxml"))
                {
                    var qe = Messages.FetchXmlToQueryExpression(service, view["fetchxml"].ToString());

                    //Main
                    var attrs = Messages.RetrieveEntity(service, qe.EntityName, EntityFilters.Attributes);

                    if (attrs == null)
                    {
                        throw new Exception($"Cannot retrieve attributes from {qe.EntityName}");
                    }

                    var attributes = new Dictionary<string,string>();

                    attributes = qe.ColumnSet.Columns.Select(column => attrs.Attributes.FirstOrDefault(x => x.LogicalName == column))
                        .Where(attr => attr != null)
                        .ToDictionary(attr => attr.LogicalName, attr => attr.DisplayName.UserLocalizedLabel.Label);

                    //Remove Primary Id Attribute
                    attributes.Remove(attrs.PrimaryIdAttribute);

                    //Get all LinkEntity's Attribute into Dictionary
                    foreach (var linkEntity in qe.LinkEntities)
                    {
                        attrs = Messages.RetrieveEntity(service, linkEntity.LinkToEntityName, EntityFilters.Attributes);

                        foreach (var attrMetadata in linkEntity.Columns.Columns.Select(column =>
                                attrs.Attributes.FirstOrDefault(x => x.LogicalName == column))
                            .Where(attr => attrs != null))
                        {
                            attributes.Add($"{linkEntity.EntityAlias}.{attrMetadata.LogicalName}", attrMetadata.DisplayName.UserLocalizedLabel.Label);
                        }

                        //Get all Next LinkEntity's Attribute into Dictionary
                        foreach (var a in GetLinkEntities(service, linkEntity.LinkEntities.ToList()))
                        {
                            attributes.Add(a.Key, a.Value.DisplayName.UserLocalizedLabel.Label);
                        }
                    }

                    if (!useLayoutXml) return attributes;
                    {
                        if (!view.Contains("layoutxml")) return attributes;

                        var xml = new XmlDocument();
                        xml.LoadXml(view["layoutxml"].ToString());
                        var xnList = xml.GetElementsByTagName("cell");

                        var orderedAttributes = (from XmlNode xn in xnList where xn.Attributes != null select xn.Attributes["name"].Value).ToList();

                        //Order
                        attributes = attributes.OrderBy(x => orderedAttributes.IndexOf(x.Key)).ToDictionary(x => x.Key, x => x.Value);
                    }

                    return attributes;
                }
                else
                {
                    throw new Exception("Cannot find fetchxml string");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Retrieve view's entity AttributeMetaData
        /// </summary>
        /// <param name="service"></param>
        /// <param name="viewId"></param>
        /// <returns></returns>
        public static IEnumerable<AttributeMetadata> RetrieveEntityAttributeMetadata(IOrganizationService service, Guid viewId)
        {
            try
            {
                var view = RetrieveView(service, viewId);

                return Messages.RetrieveEntity(service, view.LogicalName, EntityFilters.Attributes).Attributes;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve Columns(Attributes) From View as Dictionary(logical name, attributeMetaData)
        /// </summary>
        /// <param name="service"></param>
        /// <param name="viewId"></param>
        /// <param name="useLayoutXml">for order</param>
        /// <returns></returns>
        public static Dictionary<string, AttributeMetadata> RetrieveAttributeMetadata(IOrganizationService service, Guid viewId, bool useLayoutXml = false)
        {
            try
            {
                var view = RetrieveView(service, viewId);

                if (view.Contains("fetchxml"))
                {
                    var qe = Messages.FetchXmlToQueryExpression(service, view["fetchxml"].ToString());

                    //Main
                    var attrs = Messages.RetrieveEntity(service, qe.EntityName, EntityFilters.Attributes);

                    if (attrs == null)
                    {
                        throw new Exception($"Cannot retrieve attributes from {qe.EntityName}");
                    }

                    var metadatas = new Dictionary<string, AttributeMetadata>();
                    metadatas = qe.ColumnSet.Columns.Select(column => attrs.Attributes.FirstOrDefault(x => x.LogicalName == column))
                        .Where(attr => attr != null)
                        .ToDictionary(attr => attr.LogicalName, attr => attr);

                    //Remove Primary Id Attribute
                    metadatas.Remove(attrs.PrimaryIdAttribute);

                    //Get all LinkEntity's Attribute into Dictionary
                    foreach (var linkEntity in qe.LinkEntities)
                    {
                        attrs = Messages.RetrieveEntity(service, linkEntity.LinkToEntityName, EntityFilters.Attributes);

                        foreach (var attrMetadata in linkEntity.Columns.Columns.Select(column =>
                                attrs.Attributes.FirstOrDefault(x => x.LogicalName == column))
                            .Where(attr => attrs != null))
                        {
                            metadatas.Add($"{linkEntity.EntityAlias}.{attrMetadata.LogicalName}", attrMetadata);
                        }

                        //Get all Next LinkEntity's Attribute into Dictionary
                        foreach (var a in GetLinkEntities(service, linkEntity.LinkEntities.ToList()))
                        {
                            metadatas.Add(a.Key, a.Value);
                        }
                    }

                    if (!useLayoutXml) return metadatas;
                    {
                        if (!view.Contains("layoutxml")) return metadatas;
                        var xml = new XmlDocument();
                        xml.LoadXml(view["layoutxml"].ToString());
                        var xnList = xml.GetElementsByTagName("cell");

                        var attributes = (from XmlNode xn in xnList where xn.Attributes != null select xn.Attributes["name"].Value).ToList();

                        //Order
                        metadatas = metadatas.OrderBy(x => attributes.IndexOf(x.Key)).ToDictionary(x => x.Key, x => x.Value);
                    }

                    return metadatas;
                }
                else
                {
                    throw new Exception("Cannot find fetchxml string");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static Dictionary<string, AttributeMetadata> GetLinkEntities(IOrganizationService service, List<LinkEntity> linkEntities)
        {
            var metadatas = new Dictionary<string, AttributeMetadata>();

            foreach (var linkEntity in linkEntities)
            {
                var attrs = Messages.RetrieveEntity(service, linkEntity.LinkToEntityName, EntityFilters.Attributes);

                foreach (var attrMetadata in linkEntity.Columns.Columns.Select(column =>
                        attrs.Attributes.FirstOrDefault(x => x.LogicalName == column))
                    .Where(attr => attrs != null))
                {
                    metadatas.Add($"{linkEntity.EntityAlias}.{attrMetadata.LogicalName}", attrMetadata);
                }

                foreach (var a in GetLinkEntities(service, linkEntity.LinkEntities.ToList()))
                {
                    metadatas.Add(a.Key, a.Value);
                }
            }

            return metadatas;
        }

        /// <summary>
        /// Retrieve Entities(Records) By View
        /// </summary>
        /// <param name="service"></param>
        /// <param name="viewId"></param>
        /// <returns></returns>
        public static EntityCollection RetrieveEntities(IOrganizationService service, Guid viewId)
        {
            try
            {
                var view = RetrieveView(service, viewId);
                if (view.Contains("fetchxml"))
                {
                    return service.RetrieveMultiple(new FetchExpression(view["fetchxml"].ToString()));
                }
                else
                {
                    throw new Exception("Cannot find fetchxml string");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
