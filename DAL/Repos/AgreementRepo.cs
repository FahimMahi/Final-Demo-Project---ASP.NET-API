using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AgreementRepo : Repo, IRepoDurjoy<Agreement, int>
    {

        public void Create(Agreement obj)
        {
            db.Agreements.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var exobj = Get(id);
            db.Agreements.Remove(exobj);
            db.SaveChanges();
        }

        public List<Agreement> Get()
        {
            return db.Agreements.ToList();
        }

        public Agreement Get(int id)
        {
            return db.Agreements.Find(id);
        }

        public object Read()
        {
            return db.Buyers.ToList();
        }

        public void Update(Agreement obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
