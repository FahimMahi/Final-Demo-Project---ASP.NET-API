using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PaymentRepo : Repo, IRepo<Payment, int>
    {
        public void Create(Payment obj)
        {
            db.Payments.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Payments.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Payment> Read()
        {
            return db.Payments.ToList();
        }

        public Payment Read(int id)
        {
            return db.Payments.Find(id);
        }

        public void Update(Payment obj)
        {
            var ex = Read(obj.id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
