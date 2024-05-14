using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReviewRepo : Repo, IRepo<Review, int>
    {
        public void Create(Review obj)
        {
            db.Reviews.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Reviews.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Review> Read()
        {
            return db.Reviews.ToList();
        }

        public Review Read(int id)
        {
            return db.Reviews.Find(id);
        }

        public void Update(Review obj)
        {
            var ex = Read(obj.id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
