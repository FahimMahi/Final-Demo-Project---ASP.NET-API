using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MembershipRepo : Repo, IRepo<Membership, int>
    {
        public void Create(Membership obj)
        {
            db.Memberships.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Memberships.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Membership> Read()
        {
            return db.Memberships.ToList();
        }

        public Membership Read(int id)
        {
            return db.Memberships.Find(id);
        }

        public void Update(Membership obj)
        {
            var ex = Read(obj.id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
