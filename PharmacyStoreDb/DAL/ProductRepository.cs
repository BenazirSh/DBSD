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
    public class ProductRepository : IRepository<Product>
    {

        private string ConnectionStr
        {
            get { return WebConfigurationManager.ConnectionStrings["PharmacyStr"].ConnectionString;  }
        }
        public IList<Product> GetAll()
        {
            IList<Product> Products = new List<Product>();
            using (var conn = new SqlConnection(ConnectionStr))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [ProductId], 
                                    [ProductName], 
                                    [ReleaseForm], 
                                    [ProductionDate], 
                                    [StoreCondition], 
                                    [Manufacturer], 
                                    [ExpiryDate],
                                    [Volume],
                                    [ProductType], 
                                    [price]
                                    FROM [PharmacyStoreDb]
                            ";

                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var product = new Product();
                            product.ProductId = (int)rdr.GetInt32(rdr.GetOrdinal("ProductId"));
                            product.ProductName = rdr.GetString(rdr.GetOrdinal("ProductName"));
                            product.ReleaseForm = rdr.GetString(rdr.GetOrdinal("ReleaseForm"));
                            product.ProductionDate = rdr.GetDateTime(rdr.GetOrdinal("ProductionDate"));
                            product.StoreCondition = rdr.GetString(rdr.GetOrdinal("StoreCondition"));
                            product.Manufacturer = rdr.GetString(rdr.GetOrdinal("Manufacturer"));
                            product.ExpiryDate = rdr.GetDateTime(rdr.GetOrdinal("ExpiryDate"));
                            product.Manufacturer = rdr.GetString(rdr.GetOrdinal("Manufacturer"));
                            product.Volume = rdr.GetString(rdr.GetOrdinal("Volume"));
                            product.ProductType = (ProductType)rdr.GetInt32(rdr.GetOrdinal("ProductType"));
                            product.price = rdr.GetString(rdr.GetOrdinal("price"));

                            Products.Add(product);





                        }
                    }

                }

            }

            return Products;
        }

		public Product GetById(int id)
		{
            Product product = null;
            using (var conn = new SqlConnection(ConnectionStr))
            {
                using (var cmd = conn.CreateCommand())
				{ 
                    cmd.CommandText = @"SELECT [ProductId], 
                                    [ProductName], 
                                    [ReleaseForm], 
                                    [ProductionDate], 
                                    [StoreCondition], 
                                    [Manufacturer], 
                                    [ExpiryDate],
                                    [Volume],
                                    [ProductType], 
                                    [price]
                                    FROM [PharmacyStoreDb]
                                    WHERE [ProductId] = @ProductId 
                                    ";
                    cmd.Parameters.AddWithValue("@ProductId", id);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
                            product = new Product()
                            {
                                ProductName    =reader.GetString(reader.GetOrdinal("ProductName")),
                                ReleaseForm    =reader.GetString(reader.GetOrdinal("ReleaseForm")),
                                ProductionDate =reader.GetDateTime(reader.GetOrdinal("ProductionDate")),
                                StoreCondition =reader.GetString(reader.GetOrdinal("StoreCondition ")),
                                Manufacturer   =reader.GetString(reader.GetOrdinal("Manufacturer")),
                                ExpiryDate     =reader.GetDateTime(reader.GetOrdinal("ExpiryDate ")),
                                Volume         =reader.GetString(reader.GetOrdinal("Volume")),
                                ProductType    =(ProductType)reader.GetInt32(reader.GetOrdinal("ProductType")),
                                price          =reader.GetString(reader.GetOrdinal("price")),
                            };
						}
					}
                   
				}
            }
            return product;
		}

		public void Insert(Product t)
        {
            using (DbConnection conn = new SqlConnection(ConnectionStr))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Product(
                                      SET [product_name]  	
                                         ,[release_form] 	
                                         ,[production_date]
                                         ,[store_condition]
                                         ,[manufacturer] 	
                                         ,[expiration_date]
                                         ,[volume] 		
                                         ,[product_type]   
                                         ,[price] ) VALUES (
                               @ProductName,
                               @ReleaseForm,
                               @ProductionDate,
                               @StoreCondition,         
                               @Manufacturer, 
                               @ExpiryDate, 
                               @Volume,  
                               @ProductType, 
                               @price

                            )"; 

                    DbParameter pName = cmd.CreateParameter();
                    pName.DbType = System.Data.DbType.String;
                    pName.ParameterName = "@ProductName";
                    pName.Value = t.ProductName;
                    cmd.Parameters.Add(pName);

                    DbParameter pReleaseForm = cmd.CreateParameter();
                    pReleaseForm.DbType = System.Data.DbType.String;
                    pReleaseForm.ParameterName = "@ProductionDate";
                    pReleaseForm.Value = t.ReleaseForm;
                    cmd.Parameters.Add(pReleaseForm);

                    DbParameter pStoreCond = cmd.CreateParameter();
                    pStoreCond.DbType = System.Data.DbType.String;
                    pStoreCond.ParameterName = "@StoreCondition";
                    pStoreCond.Value = t.StoreCondition;
                    cmd.Parameters.Add(pStoreCond);

                    DbParameter pManufac = cmd.CreateParameter();
                    pManufac.DbType = System.Data.DbType.String;
                    pManufac.ParameterName = "@Manufacturer";
                    pManufac.Value = t.Manufacturer;
                    cmd.Parameters.Add(pManufac);

                    DbParameter pExpiryDate = cmd.CreateParameter();
                    pExpiryDate.DbType = System.Data.DbType.String;
                    pExpiryDate.ParameterName = "@ExpiryDate";
                    pExpiryDate.Value = t.ExpiryDate;
                    cmd.Parameters.Add(pExpiryDate);

                    DbParameter pVolume = cmd.CreateParameter();
                    pVolume.DbType = System.Data.DbType.String;
                    pVolume.ParameterName = "@Volume";
                    pVolume.Value = t.Volume;
                    cmd.Parameters.Add(pVolume);

                    DbParameter pProductType = cmd.CreateParameter();
                    pProductType.DbType = System.Data.DbType.String;
                    pProductType.ParameterName = "@ProductType";
                    pProductType.Value = t.ProductType;
                    cmd.Parameters.Add(pProductType);

                    DbParameter price = cmd.CreateParameter();
                    price.DbType = System.Data.DbType.String;
                    price.ParameterName = "@price";
                    price.Value = t.price;
                    cmd.Parameters.Add(price);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

		public void Update(Product t)
		{
			using(var conn=new SqlConnection(ConnectionStr))
			{
                using (var cmd = conn.CreateCommand())
				{
                    cmd.CommandText = @"UPDATE [dbo].[product]
                                   SET [product_name]  	 =@ProductName  
                                      ,[release_form] 	 =@ReleaseForm 
                                      ,[production_date] =@ProductionDate
                                      ,[store_condition] =@StoreCondition
                                      ,[manufacturer] 	 =@Manufacturer
                                      ,[expiration_date] =@ExpirationDate
                                      ,[volume] 		 =@Volume 
                                      ,[product_type]    =@ProductType
                                      ,[price] 			 =@price      
                                 WHERE product_id =@ProductId";
                    cmd.Parameters.AddWithValue("@ProductName",    t.ProductName);
                    cmd.Parameters.AddWithValue("@ReleaseForm ",   t.ReleaseForm );
                    cmd.Parameters.AddWithValue("@ProductionDate", t.ProductionDate);
                    cmd.Parameters.AddWithValue("@StoreCondition", t.StoreCondition);
                    cmd.Parameters.AddWithValue("@Manufacturer",   t.Manufacturer);
                    cmd.Parameters.AddWithValue("@ExpiryDate",     t.ExpiryDate);
                    cmd.Parameters.AddWithValue("@Volume",         t.Volume);
                    cmd.Parameters.AddWithValue("@ProductType",    t.ProductType);
                    cmd.Parameters.AddWithValue("@price",          t.price);
                    
                   
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    
                }
			}
		}
	}
}
