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
    public class CleanerRepository : IRepository<Cleaner>
    {
        private string ConnectionStr
        {
            get { return WebConfigurationManager.ConnectionStrings["PharmacyStr"].ConnectionString; }
        }
        public IList<Cleaner> GetAll()
        {
            IList<Cleaner> Cleaners = new List<Cleaner>();
            using (var conn = new SqlConnection(ConnectionStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT first_name, last_name, mobile_phone, dob, education_level,
                            salary FROM cleaner";

                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var cleaner = new Cleaner();
                            cleaner.EmployeeId = (int)rdr.GetInt32(rdr.GetOrdinal("employee_id"));
                            cleaner.FirstName = rdr.GetString(rdr.GetOrdinal("first_name"));
                            cleaner.LastName = rdr.GetString(rdr.GetOrdinal("last_name"));
                            cleaner.MobilePhone = rdr.GetString(rdr.GetOrdinal("mobile_phone"));
                            cleaner.DoB = rdr.GetDateTime(rdr.GetOrdinal("dob"));
                            cleaner.Salary = rdr.GetString(rdr.GetOrdinal("salary"));
                            cleaner.EducationLevel = rdr.GetString(rdr.GetOrdinal("education_level"));

                            Cleaners.Add(cleaner);

                        }
                    }

                }

            }

            return Cleaners;
        }

        public void Insert(Cleaner t)
        {
            using (DbConnection conn = new SqlConnection(ConnectionStr))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO cleaner(
                                   first_name, last_name, mobile_phone, dob, salary
                            education_level) VALUES (
                               @FirstName,
                               @LastName,
                               @MobilePhone,
                               @DoB,         
                               @Salary, @EducationLevel

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

                  


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
