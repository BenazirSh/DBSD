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
    public class PharmacistRepository : IRepository<Pharmacist>
    {
        private string ConnectionStr
        {
            get { return WebConfigurationManager.ConnectionStrings["PharmacyStr"].ConnectionString; }
        }
        public IList<Pharmacist> GetAll()
        {
            IList<Pharmacist> Pharmacists = new List<Pharmacist>();
            using (var conn = new SqlConnection(ConnectionStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT first_name, last_name, mobile_phone, dob, salary
                            education_level, manager_id, branch_no FROM pharmacist";

                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var pharmacist = new Pharmacist();
                            pharmacist.EmployeeId = (int)rdr.GetInt32(rdr.GetOrdinal("employee_id"));
                            pharmacist.FirstName = rdr.GetString(rdr.GetOrdinal("first_name"));
                            pharmacist.LastName = rdr.GetString(rdr.GetOrdinal("last_name"));
                            pharmacist.MobilePhone = rdr.GetString(rdr.GetOrdinal("mobile_phone"));
                            pharmacist.DoB = rdr.GetDateTime(rdr.GetOrdinal("dob"));
                            pharmacist.Salary = rdr.GetString(rdr.GetOrdinal("salary"));
                            pharmacist.EducationLevel = rdr.GetString(rdr.GetOrdinal("education_level"));
                          //pharmacist.Manager = rdr.GetString(rdr.GetOrdinal("manager_id"));
                          //pharmacist.Branch = rdr.GetString(rdr.GetOrdinal("Volume"));


                            Pharmacists.Add(pharmacist);





                        }
                    }

                }

            }

            return Pharmacists;
        }

		public Pharmacist GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Insert(Pharmacist t)
        {
            using (DbConnection conn = new SqlConnection(ConnectionStr))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO pharmacist(
                                   first_name, last_name, mobile_phone, dob, salary
                            education_level, manager_id, branch_no) VALUES (
                               @FirstName,
                               @LastName,
                               @MobilePhone,
                               @DoB,         
                               @Salary, @EducationLevel, @Manager, @Branch

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
                    pVolume.ParameterName = "@Manager";
                    pVolume.Value = t.Manager;
                    cmd.Parameters.Add(pVolume);

                    DbParameter pProductType = cmd.CreateParameter();
                    pProductType.DbType = System.Data.DbType.String;
                    pProductType.ParameterName = "@Branch";
                    pProductType.Value = t.Branch;
                    cmd.Parameters.Add(pProductType);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

		public void Update(Pharmacist t)
		{
			throw new NotImplementedException();
		}
	}
}
