//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Data;

//namespace CrmSdkLibrary
//{
//    class ConnectionSQL
//    {
//        private SqlConnection conn;
//        public SqlConnection Conn
//        {
//            get { return conn;}
//            set { conn = value; }
//        }
//    }

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
