using PharmacyStoreDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyStoreDb.DAL
{
    public class PharmacistRepository : IRepository<Pharmacist>
    {
        public IList<Pharmacist> GetAll()
        {
            throw new NotImplementedException();
        }

		public Pharmacist GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Insert(Pharmacist t)
        {
            throw new NotImplementedException();
        }

		public void Update(Pharmacist t)
		{
			throw new NotImplementedException();
		}
	}
}