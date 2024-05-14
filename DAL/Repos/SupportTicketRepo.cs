using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SupportTicketRepo : Repo, IRepo<SupportTicket, int>
    {
        public void Create(SupportTicket obj)
        {
            db.SupportTickets.Add(obj);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.SupportTickets.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<SupportTicket> Read()
        {
            return db.SupportTickets.ToList();
        }

        public SupportTicket Read(int id)
        {
            return db.SupportTickets.Find(id);
        }

        public void Update(SupportTicket obj)
        {
            var ex = Read(obj.id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
