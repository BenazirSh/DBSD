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
    public class BranchRepository : IRepository<Branch>
    {

        private string ConnectionStr
        {
            get { return WebConfigurationManager.ConnectionStrings["PharmacyStr"].ConnectionString; }
        }
        public IList<Branch> GetAll()
        {
            IList<Branch> Branches = new List<Branch>();
            using (var conn = new SqlConnection(ConnectionStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT branch_name, address_city, address_zip, address_street, cleaner_id
                         manager_id FROM branch";

                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var branch = new Branch();
                            branch.BranchId = (int)rdr.GetInt32(rdr.GetOrdinal("employee_id"));
                            branch.BranchName = rdr.GetString(rdr.GetOrdinal("branch_name"));
                            branch.BranchAddressCity = rdr.GetString(rdr.GetOrdinal("last_name"));
                            branch.BranchAddressZip = rdr.GetString(rdr.GetOrdinal("mobile_phone"));
                            branch.BranchAddressStreet = rdr.GetString(rdr.GetOrdinal("dob"));
                        //    branch.Cleaner = rdr.GetInt32(rdr.GetOrdinal("cleaner_id"));
                        //    branch.Manager = rdr.GetInt32(rdr.GetOrdinal("manager_id"));
                       


                           Branches.Add(branch);





                        }
                    }

                }

            }

            return Branches;
        }

		public Branch GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Insert(Branch t)
        {
            using (DbConnection conn = new SqlConnection(ConnectionStr))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO branch(
                                  branch_name, address_city, address_zip, address_street, cleaner_id
                         manager_id ) VALUES (
                               @BranchName,
                               @BranchAddressCity,
                               @BranchAddressZip,
                               @BranchAddressStreet,         
                               @Manager, @Cleaner

                            )";

                    DbParameter pName = cmd.CreateParameter();
                    pName.DbType = System.Data.DbType.String;
                    pName.ParameterName = "@BranchName";
                    pName.Value = t.BranchName;
                    cmd.Parameters.Add(pName);



                    DbParameter pProDate = cmd.CreateParameter();
                    pProDate.DbType = System.Data.DbType.String;
                    pProDate.ParameterName = "@BranchAddressCity";
                    pProDate.Value = t.BranchAddressCity;
                    cmd.Parameters.Add(pProDate);

                    DbParameter pStoreCond = cmd.CreateParameter();
                    pStoreCond.DbType = System.Data.DbType.String;
                    pStoreCond.ParameterName = "@BranchAddressZip";
                    pStoreCond.Value = t.BranchAddressZip;
                    cmd.Parameters.Add(pStoreCond);

                    DbParameter pReleaseForm = cmd.CreateParameter();
                    pReleaseForm.DbType = System.Data.DbType.String;
                    pReleaseForm.ParameterName = "@BranchAddressStreet";
                    pReleaseForm.Value = t.BranchAddressStreet;
                    cmd.Parameters.Add(pStoreCond);

                    DbParameter pManufac = cmd.CreateParameter();
                    pManufac.DbType = System.Data.DbType.String;
                    pManufac.ParameterName = "@Manager";
                    pManufac.Value = t.Manager;
                    cmd.Parameters.Add(pManufac);

                    DbParameter pExpiryDate = cmd.CreateParameter();
                    pExpiryDate.DbType = System.Data.DbType.String;
                    pExpiryDate.ParameterName = "@Cleaner";
                    pExpiryDate.Value = t.Cleaner;
                    cmd.Parameters.Add(pExpiryDate);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

		public void Update(Branch t)
		{
			throw new NotImplementedException();
		}
	}
}
