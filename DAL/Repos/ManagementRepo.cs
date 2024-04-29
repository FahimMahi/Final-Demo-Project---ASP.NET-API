using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ManagementRepo : Repo, IRepo<Management, int>
    {
        public void Create(Management obj)
        {
            db.Managements.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Managements.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Management> Read()
        {
            return db.Managements.ToList();
        }

        public Management Read(int id)
        {
            return db.Managements.Find(id);
        }

        public void Update(Management obj)
        {
            var ex = Read(obj.id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
