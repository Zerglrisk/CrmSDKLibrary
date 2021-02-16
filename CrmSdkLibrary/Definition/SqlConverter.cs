using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CrmSdkLibrary.Definition.Enum;
using CrmSdkLibrary.Definition.Model;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;

namespace CrmSdkLibrary.Definition
{
    public class SqlConverter
    {
        public static SqlWrapper Convert(string fetchXml, string layoutXml = "")
        {
            return Convert(Messages.FetchXmlToQueryExpression(Connection.Service, fetchXml), layoutXml);
        }

        /// <summary>
        /// Convert To SqlWrapper
        /// Need to Add Conditions
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="layoutXml"></param>
        /// <returns></returns>
        public static SqlWrapper Convert(QueryExpression queryExpression, string layoutXml = "")
        {
            if (queryExpression == null) return null;

            var sqlWrapper = new SqlWrapper()
            {
                From = queryExpression.EntityName
            };

            sqlWrapper.SetLayoutColumns(layoutXml);

            #region Columns

            var attrs = Messages.RetrieveEntity(Connection.Service, queryExpression.EntityName, EntityFilters.Attributes);
            foreach (var attrMetadata in queryExpression.ColumnSet.Columns.Select(column => attrs.Attributes.FirstOrDefault(x=>x.LogicalName == column)).Where(attr => attr != null))
            {
                sqlWrapper.Columns.Add(attrMetadata.LogicalName, attrMetadata.DisplayName.UserLocalizedLabel.Label);
                sqlWrapper.SetLayoutColumnsDisplayName(attrMetadata.LogicalName, attrMetadata.DisplayName.UserLocalizedLabel.Label);
            }
            #endregion

            foreach (var aa in queryExpression.Criteria.Conditions)
            {
                sqlWrapper.Conditions.Add(new SqlWrapper.Condition()
                {
                    ColumnName = aa.AttributeName,
                    Value =  aa.Values.ToList(),
                    ConditionType =  (ConditionType) aa.Operator
                });
            }

            #region Order
            var index = 0;
            foreach (var order in queryExpression.Orders)
            {
                sqlWrapper.Orders.Add(new SqlWrapper.Order() { ColumnName = order.AttributeName, SortDirection = order.OrderType == OrderType.Ascending ? SortDirection.Ascending : SortDirection.Descending, Index = index });
                index++;
            }

            #endregion

            #region Join
            foreach (var entity in queryExpression.LinkEntities)
            {
             sqlWrapper.Join.Add(GetSqlJoinWrapper(entity, ref sqlWrapper));   
            } 
            #endregion
            return sqlWrapper;
        }

        private static SqlJoinWrapper GetSqlJoinWrapper(LinkEntity entity, ref SqlWrapper sqlWrapper)
        {
            var sqlJoinWrapper = new SqlJoinWrapper()
            {
                From = entity.LinkToEntityName,
                JoinFromAttributeName = entity.LinkFromAttributeName,
                JoinToAttributeName = entity.LinkToAttributeName,
                Alias = entity.EntityAlias
            };
            var attrs = Messages.RetrieveEntity(Connection.Service, entity.LinkToEntityName, EntityFilters.Attributes);
            foreach (var attrMetadata in entity.Columns.Columns.Select(column => attrs.Attributes.FirstOrDefault(x => x.LogicalName == column)).Where(attr => attr != null))
            {
                sqlJoinWrapper.Columns.Add(attrMetadata.LogicalName, attrMetadata.DisplayName.UserLocalizedLabel.Label);
                sqlWrapper.SetLayoutColumnsDisplayName($"{entity.EntityAlias}.{attrMetadata.LogicalName}", attrMetadata.DisplayName.UserLocalizedLabel.Label);
            }

            foreach (var aa in entity.LinkCriteria.Conditions)
            {
                sqlJoinWrapper.Conditions.Add(new SqlWrapper.Condition()
                {
                    ColumnName = aa.AttributeName,
                    Value = aa.Values.ToList(),
                    ConditionType = (ConditionType)aa.Operator
                });
            }

            #region Order
            var index = 0;
            foreach (var order in entity.Orders)
            {
                sqlJoinWrapper.Orders.Add(new SqlWrapper.Order() { ColumnName = order.AttributeName, SortDirection = order.OrderType == OrderType.Ascending ? SortDirection.Ascending : SortDirection.Descending, Index = index });
                index++;
            }

            #endregion

            #region Join
            foreach (var link in entity.LinkEntities)
            {
                sqlJoinWrapper.Join.Add(GetSqlJoinWrapper(link, ref sqlWrapper));
            }
            #endregion

            return sqlJoinWrapper;
        }
    }
}
