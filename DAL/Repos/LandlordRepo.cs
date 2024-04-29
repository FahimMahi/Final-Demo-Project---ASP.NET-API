using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LandlordRepo : Repo, IRepo<Landlord, int>
    {
        public void Create(Landlord obj)
        {
            db.Landlords.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Landlords.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Landlord> Read()
        {
            return db.Landlords.ToList();
        }

        public Landlord Read(int id)
        {
            return db.Landlords.Find(id);
        }

        public void Update(Landlord obj)
        {
            var ex = Read(obj.id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
