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
    public class ManagerRepository : IRepository<Manager>
    {
        private string ConnectionStr
        {
            get { return WebConfigurationManager.ConnectionStrings["PharmacyStr"].ConnectionString; }
        }
        public IList<Manager> GetAll()
        {
            IList<Manager> Managers = new List<Manager>();
            using (var conn = new SqlConnection(ConnectionStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT first_name, last_name, mobile_phone, dob, salary
                            education_level,ranking FROM manager";

                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var manager = new Manager();
                            manager.EmployeeId = (int)rdr.GetInt32(rdr.GetOrdinal("employee_id"));
                            manager.FirstName = rdr.GetString(rdr.GetOrdinal("first_name"));
                            manager.LastName = rdr.GetString(rdr.GetOrdinal("last_name"));
                            manager.MobilePhone = rdr.GetString(rdr.GetOrdinal("mobile_phone"));
                            manager.DoB = rdr.GetDateTime(rdr.GetOrdinal("dob"));
                            manager.Salary = rdr.GetString(rdr.GetOrdinal("salary"));
                            manager.EducationLevel = rdr.GetString(rdr.GetOrdinal("education_level"));
                            manager.Ranking = rdr.GetInt32(rdr.GetOrdinal("ranking"));


                            Managers.Add(manager);





                        }
                    }

                }

            }

            return Managers;
        }

		public Manager GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Insert(Manager t)
        {
            using (DbConnection conn = new SqlConnection(ConnectionStr))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO manager(
                                   first_name, last_name, mobile_phone, dob, salary
                            education_level, manager_id, branch_no) VALUES (
                               @FirstName,
                               @LastName,
                               @MobilePhone,
                               @DoB,         
                               @Salary, @EducationLevel, @Ranking

                            )";

                    DbParameter pName = cmd.CreateParameter();
                    pName.DbType = System.Data.DbType.String;
                    pName.ParameterName = "@FirstName";
                    pName.Value = t.FirstName;
                    cmd.Parameters.Add(pName);



                    DbParameter pProDate = cmd.CreateParameter();
                    pProDate.DbType = System.Data.DbType.String;
                    pProDate.ParameterName = "@LastName";
                    pProDate.Value = t.LastName;
                    cmd.Parameters.Add(pProDate);

                    DbParameter pStoreCond = cmd.CreateParameter();
                    pStoreCond.DbType = System.Data.DbType.String;
                    pStoreCond.ParameterName = "@MobilePhone";
                    pStoreCond.Value = t.MobilePhone;
                    cmd.Parameters.Add(pStoreCond);

                    DbParameter pReleaseForm = cmd.CreateParameter();
                    pReleaseForm.DbType = System.Data.DbType.String;
                    pReleaseForm.ParameterName = "@DoB";
                    pReleaseForm.Value = t.DoB;
                    cmd.Parameters.Add(pStoreCond);

                    DbParameter pManufac = cmd.CreateParameter();
                    pManufac.DbType = System.Data.DbType.String;
                    pManufac.ParameterName = "@Salary";
                    pManufac.Value = t.Salary;
                    cmd.Parameters.Add(pManufac);

                    DbParameter pExpiryDate = cmd.CreateParameter();
                    pExpiryDate.DbType = System.Data.DbType.String;
                    pExpiryDate.ParameterName = "@EducationLevel";
                    pExpiryDate.Value = t.EducationLevel;
                    cmd.Parameters.Add(pExpiryDate);

                    DbParameter pVolume = cmd.CreateParameter();
                    pVolume.DbType = System.Data.DbType.String;
                    pVolume.ParameterName = "@Ranking";
                    pVolume.Value = t.Ranking;
                    cmd.Parameters.Add(pVolume);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

		public void Update(Manager t)
		{
			throw new NotImplementedException();
		}
	}
}
