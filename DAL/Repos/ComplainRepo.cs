using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ComplainRepo : Repo, IRepoDurjoy<Complain, int>
    {
        public void Create(Complain obj)
        {
            db.Complains.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var exobj = Get(id);
            if (exobj != null)
            {
                db.Complains.Remove(exobj);
                db.SaveChanges();
            }
        }

        public List<Complain> Get()
        {
            return db.Complains.ToList();
        }

        public Complain Get(int id)
        {
            return db.Complains.Find(id);
        }

        public object Read()
        {
            return db.Complains.ToList();
        }

        public void Update(Complain obj)
        {
            var exobj = Get(obj.Id);
            if (exobj != null)
            {
                db.Entry(exobj).CurrentValues.SetValues(obj);
                db.SaveChanges();
            }
        }
    }
}
