using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FeedbackRepo : Repo, IRepo<Feedback, int>
    {
        public void Create(Feedback obj)
        {
            db.Feedbacks.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Feedbacks.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Feedback> Read()
        {
            return db.Feedbacks.ToList();
        }

        public Feedback Read(int id)
        {
            return db.Feedbacks.Find(id);
        }

        public void Update(Feedback obj)
        {
            var ex = Read(obj.id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
