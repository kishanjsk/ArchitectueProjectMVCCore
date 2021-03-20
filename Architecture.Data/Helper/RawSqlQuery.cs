using Architecture.DataBase.DatabaseFirst;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Architecture.DataBase.Helper
{
    public class RawSqlQuery
    {
        private readonly AdminContext _context;


        public RawSqlQuery(AdminContext context)
        {
            _context = context;
        }

        public List<T> GetWithRawSql<T>(string query, Func<DbDataReader, T> map, params object[] parameters)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                _context.Database.OpenConnection();
                command.Parameters.AddRange(parameters);
                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();

                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }

                    return entities;
                }
            }
        }

        public List<object> GetData(string SPNAME, string TenantID, long? productId)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = SPNAME;

                command.Parameters.Add(new SqlParameter("@TenantId", SqlDbType.NVarChar) { Value = TenantID });
                command.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.BigInt) { Value = productId });

                _context.Database.OpenConnection();
                command.CommandType = CommandType.StoredProcedure;
                var rdr = command.ExecuteReader();

                var dataTable = new DataTable();
                dataTable.Load(rdr);
                //return dataTable.AsEnumerable().Select(x => new Data
                //{
                //    Id = x.Field<long?>(0),
                //    Nane = x.Field<long?>(1),
                //    Salary = x.Field<long?>(2),
                //     .... EXTRA FIELDS
                //}).ToList();
                return null;
            }
        }
    }
}
