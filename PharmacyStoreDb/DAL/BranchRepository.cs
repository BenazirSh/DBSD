using PharmacyStoreDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyStoreDb.DAL
{
    public class BranchRepository : IRepository<Branch>
    {
        public IList<Branch> GetAll()
        {
            throw new NotImplementedException();
        }

		public Branch GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Insert(Branch t)
        {
            throw new NotImplementedException();
        }

		public void Update(Branch t)
		{
			throw new NotImplementedException();
		}
	}
}