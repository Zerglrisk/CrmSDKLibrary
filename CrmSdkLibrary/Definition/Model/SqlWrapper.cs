using CrmSdkLibrary.Definition.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CrmSdkLibrary.Definition.Model
{
	public class SqlWrapper
	{
		public ColumnSet LayoutColumns { get; private set; }
		public ColumnSet Columns { get; set; }

		public bool Sorted { get; set; }
		public List<Order> Orders { get; set; }
		public string From { get; set; }
		public List<SqlJoinWrapper> Join { get; set; }

		public List<Condition> Conditions { get; set; }

		public SqlWrapper()
		{
			Sorted = false;
			Columns = new ColumnSet();
			Orders = new List<Order>();
			LayoutColumns = new ColumnSet();
			Join = new List<SqlJoinWrapper>();
			Conditions = new List<Condition>();
		}

		public void SetLayoutColumns(string layoutXml)
		{
			if (string.IsNullOrWhiteSpace(layoutXml)) return;

			var xml = new XmlDocument();
			xml.LoadXml(layoutXml);
			var xnList = xml.GetElementsByTagName("cell");

			this.LayoutColumns.AddRange((from XmlNode xn in xnList where xn.Attributes != null select xn.Attributes["name"].Value).ToList());
		}

		public bool SetLayoutColumnsDisplayName(string name, string displayName)
		{
			if (string.IsNullOrWhiteSpace(name)) return false;
			var col = this.LayoutColumns.FirstOrDefault(x => x.Name == name);
			if (col != null) col.DisplayName = displayName;
			return true;
		}

		/// <summary>
		/// Need to Add Condition
		/// </summary>
		/// <returns></returns>
		public string GenerateSql()
		{
			var query = "SELECT ";
			var attributes = this.LayoutColumns.OrderBy(x => x.Index).Select(x => x.Name.Contains(".") ? x.Name : $"{this.From}.{x.Name}");
			query += string.Join(", ", attributes);
			query += $" FROM {this.From} ";
			foreach (var link in Join)
			{
				query += GenerateJoinSql(link);
			}

			if (Orders.Count > 0)
			{
				query += " ORDER BY ";
				var orderString = new List<string>();
				foreach (var order in Orders.OrderBy(x => x.Index))
				{
					orderString.Add($"{this.From}.{order.ColumnName} {order.SortDirection.GetStringValue()}");
				}
				query += string.Join(", ", orderString);
			}

			return query;
		}

		/// <summary>
		/// Need to add Condition
		/// </summary>
		/// <param name="join"></param>
		/// <returns></returns>
		private string GenerateJoinSql(SqlJoinWrapper join)
		{
			var query = "";

			query += $"{join.JoinType.GetStringValue()} JOIN {join.From} ";
			if (!string.IsNullOrWhiteSpace(join.Alias))
			{
				query += $"AS {join.Alias} ";
			}
			query += $"ON ({this.From}.{join.JoinFromAttributeName} = {join.Alias}.{join.JoinToAttributeName} ";

			var conditionString = new List<string>();
			foreach (var condition in join.Conditions)
			{
				conditionString.Add($"({join.Alias}.{condition.ColumnName} {condition.ConditionType.GetStringValue()} {string.Join(", ", condition.Value)})");
			}

			query += (conditionString.Count > 0 ? "AND " : "") + string.Join(" AND ", conditionString);
			query += " ) ";
			foreach (var link in join.Join)
			{
				query += GenerateJoinSql(link);
			}
			return query;
		}

		public class Column
		{
			public int Index { get; set; }
			public string Name { get; set; }
			public string DisplayName { get; set; }

			public Column(string name)
			{
				this.Name = name;
			}

			public Column(string name, string displayName)
			{
				this.Name = name;
				this.DisplayName = displayName;
			}
		}

		public class ColumnSet : List<Column>
		{
			public void Add(string name)
			{
				this.Add(new Column(name)
				{
					Index = Count
				});
			}

			public void Add(string name, string displayName)
			{
				this.Add(new Column(name, displayName)
				{
					Index = Count
				});
			}

			public void AddRange(List<string> names)
			{
				foreach (var name in names)
				{
					this.Add(name);
				}
			}
		}

		public class Order
		{
			public int Index { get; set; }
			public string ColumnName { get; set; }
			public SortDirection SortDirection { get; set; }
		}

		public class Condition
		{
			public string ColumnName { get; set; }
			public List<object> Value { get; set; }

			public ConditionType ConditionType { get; set; }
		}
	}

	public class SqlJoinWrapper
	{
		public SqlWrapper.ColumnSet Columns { get; set; }

		public List<SqlWrapper.Order> Orders { get; set; }
		public string From { get; set; }
		public JoinType JoinType { get; set; }
		public List<SqlWrapper.Condition> Conditions { get; set; }
		public string Alias { get; set; }

		/// <summary>
		/// parent
		/// </summary>
		public string JoinFromAttributeName { get; set; }

		public string JoinToAttributeName { get; set; }
		public List<SqlJoinWrapper> Join { get; set; }

		public SqlJoinWrapper()
		{
			Columns = new SqlWrapper.ColumnSet();
			Orders = new List<SqlWrapper.Order>();
			Join = new List<SqlJoinWrapper>();
			Conditions = new List<SqlWrapper.Condition>();
		}
	}
}