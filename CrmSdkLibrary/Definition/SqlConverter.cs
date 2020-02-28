using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CrmSdkLibrary.Definition.Enum;
using CrmSdkLibrary.Definition.Model;
using Microsoft.Xrm.Sdk.Query;

namespace CrmSdkLibrary.Definition
{
    public class SqlConverter
    {
        public static SqlWrapper Convert(string fetchXml, string layoutXml = "")
        {
            return Convert(Messages.FetchXmlToQueryExpression(Connection.OrgService, fetchXml), layoutXml);
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
            sqlWrapper.Columns.AddRange(queryExpression.ColumnSet.Columns.ToList());

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
             sqlWrapper.Join.Add(GetSqlJoinWrapper(entity));   
            } 
            #endregion
            return sqlWrapper;
        }

        private static SqlJoinWrapper GetSqlJoinWrapper(LinkEntity entity)
        {
            var sqlWrapper = new SqlJoinWrapper()
            {
                From = entity.LinkToEntityName,
                JoinFromAttributeName = entity.LinkFromAttributeName,
                JoinToAttributeName = entity.LinkToAttributeName,
                Alias = entity.EntityAlias
            };
            
            sqlWrapper.Columns.AddRange(entity.Columns.Columns.ToList());

            #region Order
            var index = 0;
            foreach (var order in entity.Orders)
            {
                sqlWrapper.Orders.Add(new SqlWrapper.Order() { ColumnName = order.AttributeName, SortDirection = order.OrderType == OrderType.Ascending ? SortDirection.Ascending : SortDirection.Descending, Index = index });
                index++;
            }

            #endregion

            #region Join
            foreach (var link in entity.LinkEntities)
            {
                sqlWrapper.Join.Add(GetSqlJoinWrapper(link));
            }
            #endregion

            return sqlWrapper;
        }
    }
}
