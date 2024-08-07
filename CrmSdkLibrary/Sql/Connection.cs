using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Dynamic;

namespace CrmSdkLibrary.Sql
{
    public partial class Connection
    {
        public SqlConnection SqlConnection { get; private set; }

        public Connection() { }


        public Connection(string connectionString)
        {
            SetConnection(connectionString);
        }

        public void SetConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));

            this.SqlConnection = new SqlConnection(connectionString);
        }
    }
    public static class SqlConnectionExtensions
    {
        public static List<T> ExecuteQueryWithRetry<T, P>(this SqlConnection connection, string sql, P parameters, int maxRetries = 3) where T : class, new()
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection), "SqlConnection cannot be null.");

            int retryCount = 0;
            while (true)
            {
                try
                {
                    return ExecuteQueryInternal<T, P>(connection, sql, parameters);
                }
                catch (SqlException ex)
                {
                    if (retryCount >= maxRetries || !IsTransientError(ex))
                        throw;

                    retryCount++;
                    System.Threading.Thread.Sleep(1000 * retryCount); // 간단한 지수 백오프
                }
            }
        }

        private static List<T> ExecuteQueryInternal<T, P>(SqlConnection connection, string sql, P parameters) where T : class, new()
        {
            var result = new List<T>();

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (var command = new SqlCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var prop in typeof(P).GetProperties())
                        {
                            command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(parameters) ?? DBNull.Value);
                        }
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(MapReaderToClass<T>(reader));
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw; // SqlException을 그대로 다시 throw
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An unexpected error occurred while processing the query.", ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return result;
        }

        private static T MapReaderToClass<T>(IDataReader reader) where T : class, new()
        {
            T item = new T();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (HasColumn(reader, property.Name))
                {
                    var value = reader[property.Name];
                    if (value != DBNull.Value)
                    {
                        property.SetValue(item, Convert.ChangeType(value, property.PropertyType));
                    }
                }
            }

            return item;
        }

        private static bool HasColumn(IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private static bool IsTransientError(SqlException ex)
        {
            int[] transientErrorNumbers = { 4060, 40197, 40501, 40613, 49918, 49919, 49920 };
            return transientErrorNumbers.Contains(ex.Number);
        }
    }
}

//    u
//namespace TIFW.DB
//    {
//        public class Dapper
//        {
//            private string ConnectionString = "";
//            private Parameters _params = new Parameters();
//            public IParameters Params { get { return _params; } }
//            public Dapper(string conName, string skey)
//            {
//                //if (Common.Config.IsRelease)
//                //{
//                //  ConnectionString = new Crypto().Decrypt(ConfigurationManager.ConnectionStrings[conName].ConnectionString, skey);
//                //}
//                //else
//                //{
//                ConnectionString = ConfigurationManager.ConnectionStrings[conName].ConnectionString;
//                //}
//            }
//            public void ParameterClear()
//            {
//                _params = new Parameters();
//            }
//            public int Execute(string ProcName)
//            {
//                int res;
//                using (IDbConnection cnn = new SqlConnection(ConnectionString))
//                {
//                    res = cnn.Execute(ProcName, _params.GetParams(), commandType: new CommandType?(CommandType.StoredProcedure));
//                }
//                return res;
//            }
//            public T First<T>(string ProcName)
//            {
//                T res;
//                using (IDbConnection cnn = new SqlConnection(ConnectionString))
//                {
//                    res = cnn.QueryFirst<T>(ProcName, _params.GetParams(), commandType: new CommandType?(CommandType.StoredProcedure));
//                }
//                return res;
//            }
//            public List<T> List<T>(string ProcName)
//            {
//                List<T> res = new List<T>();
//                using (IDbConnection cnn = new SqlConnection(ConnectionString))
//                {
//                    res = cnn.Query<T>(ProcName, _params.GetParams(), commandType: new CommandType?(CommandType.StoredProcedure)).ToList();
//                }
//                return res;
//            }
//            public Tuple<List<T1>, List<T2>> ListMultiple<T1, T2>(string ProcName)
//            {
//                SqlMapper.GridReader gridReader = QueryMultiple(ProcName);
//                gridReader.Read<T1>();
//                Tuple<List<T1>, List<T2>> res
//                    = new Tuple<List<T1>, List<T2>>(gridReader.Read<T1>().ToList()
//                                                  , gridReader.Read<T2>().ToList()
//                                                  );
//                return res;
//            }
//            public Tuple<List<T1>, List<T2>, List<T3>> ListMultiple<T1, T2, T3>(string ProcName)
//            {
//                SqlMapper.GridReader gridReader = QueryMultiple(ProcName);
//                gridReader.Read<T1>();
//                Tuple<List<T1>, List<T2>, List<T3>> res
//                    = new Tuple<List<T1>, List<T2>, List<T3>>(gridReader.Read<T1>().ToList()
//                                                            , gridReader.Read<T2>().ToList()
//                                                            , gridReader.Read<T3>().ToList()
//                                                            );
//                return res;
//            }
//            public Tuple<List<T1>, List<T2>, List<T3>, List<T4>> ListMultiple<T1, T2, T3, T4>(string ProcName)
//            {
//                SqlMapper.GridReader gridReader = QueryMultiple(ProcName);
//                gridReader.Read<T1>();
//                Tuple<List<T1>, List<T2>, List<T3>, List<T4>> res
//                    = new Tuple<List<T1>, List<T2>, List<T3>, List<T4>>(gridReader.Read<T1>().ToList()
//                                                                      , gridReader.Read<T2>().ToList()
//                                                                      , gridReader.Read<T3>().ToList()
//                                                                      , gridReader.Read<T4>().ToList()
//                                                                      );
//                return res;
//            }
//            public Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>> ListMultiple<T1, T2, T3, T4, T5>(string ProcName)
//            {
//                SqlMapper.GridReader gridReader = QueryMultiple(ProcName);
//                gridReader.Read<T1>();
//                Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>> res
//                    = new Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>>(gridReader.Read<T1>().ToList()
//                                                                                , gridReader.Read<T2>().ToList()
//                                                                                , gridReader.Read<T3>().ToList()
//                                                                                , gridReader.Read<T4>().ToList()
//                                                                                , gridReader.Read<T5>().ToList()
//                                                                                );
//                return res;
//            }
//            public Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>, List<T6>> ListMultiple<T1, T2, T3, T4, T5, T6>(string ProcName)
//            {
//                SqlMapper.GridReader gridReader = QueryMultiple(ProcName);
//                gridReader.Read<T1>();
//                Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>, List<T6>> res
//                    = new Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>, List<T6>>(gridReader.Read<T1>().ToList()
//                                                                                          , gridReader.Read<T2>().ToList()
//                                                                                          , gridReader.Read<T3>().ToList()
//                                                                                          , gridReader.Read<T4>().ToList()
//                                                                                          , gridReader.Read<T5>().ToList()
//                                                                                          , gridReader.Read<T6>().ToList()
//                                                                                          );
//                return res;
//            }
//            public Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>, List<T6>, List<T7>> ListMultiple<T1, T2, T3, T4, T5, T6, T7>(string ProcName)
//            {
//                SqlMapper.GridReader gridReader = QueryMultiple(ProcName);
//                gridReader.Read<T1>();
//                Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>, List<T6>, List<T7>> res
//                    = new Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>, List<T6>, List<T7>>(gridReader.Read<T1>().ToList()
//                                                                                                    , gridReader.Read<T2>().ToList()
//                                                                                                    , gridReader.Read<T3>().ToList()
//                                                                                                    , gridReader.Read<T4>().ToList()
//                                                                                                    , gridReader.Read<T5>().ToList()
//                                                                                                    , gridReader.Read<T6>().ToList()
//                                                                                                    , gridReader.Read<T7>().ToList()
//                                                                                                    );
//                return res;
//            }
//            public Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>, List<T6>, List<T7>, List<T8>> ListMultiple<T1, T2, T3, T4, T5, T6, T7, T8>(string ProcName)
//            {
//                SqlMapper.GridReader gridReader = QueryMultiple(ProcName);
//                gridReader.Read<T1>();
//                Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>, List<T6>, List<T7>, List<T8>> res
//                    = new Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>, List<T6>, List<T7>, List<T8>>(gridReader.Read<T1>().ToList()
//                                                                                                              , gridReader.Read<T2>().ToList()
//                                                                                                              , gridReader.Read<T3>().ToList()
//                                                                                                              , gridReader.Read<T4>().ToList()
//                                                                                                              , gridReader.Read<T5>().ToList()
//                                                                                                              , gridReader.Read<T6>().ToList()
//                                                                                                              , gridReader.Read<T7>().ToList()
//                                                                                                              , gridReader.Read<T8>().ToList()
//                                                                                                              );
//                return res;
//            }
//            private SqlMapper.GridReader QueryMultiple(string ProcName)
//            {
//                SqlMapper.GridReader gridReader = null;
//                using (IDbConnection cnn = new SqlConnection(ConnectionString))
//                {
//                    gridReader = cnn.QueryMultiple(ProcName, _params.GetParams(), commandType: new CommandType?(CommandType.StoredProcedure));
//                }
//                return gridReader;
//            }
//            private class Parameters : IParameters
//            {
//                private DynamicParameters p = new DynamicParameters();
//                public DynamicParameters GetParams()
//                {
//                    return p;
//                }
//                public T Get<T>(string ParamName)
//                {
//                    return p.Get<T>(ParamName);
//                }
//                public void Add(string name, object value, DbType? dbType, ParameterDirection? direction, int? size = null, byte? precision = null, byte? scale = null)
//                {
//                    p.Add(name, value, dbType, direction, size, precision, scale);
//                }
//            }
//        }
//        public interface IParameters
//        {
//            T Get<T>(string ParamName);
//            void Add(string name, object value, DbType? dbType, ParameterDirection? direction, int? size = null, byte? precision = null, byte? scale = null);
//        }
//    }
//}
