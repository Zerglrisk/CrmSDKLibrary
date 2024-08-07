using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CrmSdkLibrary.Sql
{
    public partial class Connection
    {
        public class OptionSet
        {
            private readonly Connection connection;

            public OptionSet(Connection connection)
            {
				this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
            }

            public List<Models.OptionSet> GetGlobalOptionSets (string optionSetName, int langId) 
            {
				if (connection.SqlConnection == null)
					throw new InvalidOperationException("SqlConnection is not initialized. Please use the constructor with connection string or call SetConnection method.");

				if (string.IsNullOrWhiteSpace(optionSetName)){
                    return null;
                }

                var sql = @"
SELECT 
[OS].[Name] AS [OptionSetName],
[LL].[Label],
[APV].[Value],
[APV].[DisplayOrder],
[APV].[Color]
FROM OptionSet AS [OS]
JOIN AttributePicklistValueView AS [APV]
ON [OS].[OptionSetId] = [APV].[OptionSetId]
LEFT JOIN LocalizedLabel AS [LL]
ON [APV].[AttributePicklistValueId] = [LL].[ObjectId]
AND [LL].ObjectColumnName = 'DisplayName'
WHERE IsGlobal = 1
AND [Name] = @P_GlobalOptionSetName
AND [LL].[LanguageId] = @P_LangId"
                ;

				var parameters = new { P_GlobalOptionSetName = optionSetName, P_LangId = langId };
				return this.connection.SqlConnection.ExecuteQueryWithRetry<Models.OptionSet, object>(sql, parameters);
			}
            public List<Models.OptionSet> GetOptionSets(string logicalEntityName, string optionSetName, int langId)
            {
                var sql = @"
SELECT 
[SM].[AttributeName] AS [OptionSetName],
[SM].[Value] AS [Label],
[SM].[AttributeValue] AS [Value],
[SM].[DisplayOrder]
FROM StringMap AS [SM]
INNER JOIN Entity AS [E]
ON [SM].[ObjectTypeCode] = [E].[ObjectTypeCode]
WHERE LOWER([AttributeName]) = LOWER(@P_OptionSetName)
AND [LangId] = @P_LangId
AND LOWER([E].[Name]) = LOWER(@P_LogicalEntityName)
";
				var parameters = new { P_LogicalEntityName = logicalEntityName, P_OptionSetName = optionSetName, P_LangId = langId };
				return this.connection.SqlConnection.ExecuteQueryWithRetry<Models.OptionSet, object>(sql, parameters);
			}
        }
    }
}
