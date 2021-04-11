using PharmacyStoreDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyStoreDb.DAL
{
    public class ManagerRepository : IRepository<Manager>
    {
        public IList<Manager> GetAll()
        {
            throw new NotImplementedException();
        }

		public Manager GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Insert(Manager t)
        {
            throw new NotImplementedException();
        }

		public void Update(Manager t)
		{
			throw new NotImplementedException();
		}
	}
}