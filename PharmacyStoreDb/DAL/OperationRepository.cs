using PharmacyStoreDb.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PharmacyStoreDb.DAL
{
    public class OperationRepository : IRepository<Operation>
    {
        private string ConnectionStr
        {
            get { return WebConfigurationManager.ConnectionStrings["PharmacyStr"].ConnectionString; }
        }
        public IList<Operation> GetAll()
        {
            IList<Operation> Operations = new List<Operation>();
            using (var conn = new SqlConnection(ConnectionStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT operation_type, operation_date, pharmacist_id, quantity, product_id
                       FROM operation";

                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var operation = new Operation();
                            operation.OperationType = rdr.GetString(rdr.GetOrdinal("operation_type"));
                            operation.OperationDate = rdr.GetDateTime(rdr.GetOrdinal("operation_date"));
                          //  operation.Pharmacist = rdr.GetString(rdr.GetOrdinal("pharmacist_id"));
                          //  operation.Quantity = rdr.GetString(rdr.GetOrdinal("quantity"));
                          //  operation.Product = rdr.GetString(rdr.GetOrdinal("product_id"));
                          


                            Operations.Add(operation);

                        }
                    }

                }

            }

            return Operations;
        }

        public void Insert(Operation t)
        {
            using (DbConnection conn = new SqlConnection(ConnectionStr))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO operation(
                                operation_type, operation_date, pharmacist_id, quantity, product_id) VALUES (
                               @OperationType,
                               @OperationDate,
                               @Pharmacist,
                               @Quantity,         
                               @Product

                            )";

                    DbParameter pName = cmd.CreateParameter();
                    pName.DbType = System.Data.DbType.String;
                    pName.ParameterName = "@OperationType";
                    pName.Value = t.OperationType;
                    cmd.Parameters.Add(pName);



                    DbParameter pProDate = cmd.CreateParameter();
                    pProDate.DbType = System.Data.DbType.String;
                    pProDate.ParameterName = "@OperationDate";
                    pProDate.Value = t.OperationDate;
                    cmd.Parameters.Add(pProDate);

                    DbParameter pStoreCond = cmd.CreateParameter();
                    pStoreCond.DbType = System.Data.DbType.String;
                    pStoreCond.ParameterName = "@Pharmacist";
                    pStoreCond.Value = t.Pharmacist;
                    cmd.Parameters.Add(pStoreCond);

                    DbParameter pReleaseForm = cmd.CreateParameter();
                    pReleaseForm.DbType = System.Data.DbType.String;
                    pReleaseForm.ParameterName = "@Quantity";
                    pReleaseForm.Value = t.Quantity;
                    cmd.Parameters.Add(pStoreCond);

                    DbParameter pManufac = cmd.CreateParameter();
                    pManufac.DbType = System.Data.DbType.String;
                    pManufac.ParameterName = "@Product";
                    pManufac.Value = t.Product;
                    cmd.Parameters.Add(pManufac);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
