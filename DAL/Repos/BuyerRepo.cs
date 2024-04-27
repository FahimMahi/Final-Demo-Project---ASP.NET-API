using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BuyerRepo : Repo, IRepo<Buyer, int>
    {
        public void Create(Buyer obj)
        {
            db.Buyers.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Buyers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Buyer> Read()
        {
            return db.Buyers.ToList();
        }

        public Buyer Read(int id)
        {
            return db.Buyers.Find(id);
        }

        public void Update(Buyer obj)
        {
            var ex = Read(obj.id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
