using PharmacyStoreDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStoreDb.DAL
{
   public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        void Insert(T t);
        T GetById(int id);//??
        void Update(T t);


    }
}
