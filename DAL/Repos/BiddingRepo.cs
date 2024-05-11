using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BiddingRepo : Repo, IRepoPropertyBidding<Bidding, int>
    {
        public Bidding Create(Bidding obj)
        {
            db.Biddings.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public List<Bidding> Delete(int id)
        {

            var exobj = db.Biddings.Where(f => f.BuyerID == id).FirstOrDefault();
            db.Biddings.Remove(exobj);
            db.SaveChanges();
            var data = Read();
            return data;



        }

        public List<Bidding> Delete(int pid, int bid)
        {
            var exobj = db.Biddings.Where(f => f.BidderId == bid && f.PropertyId == pid).ToList();

            db.Biddings.RemoveRange(exobj);
            db.SaveChanges();
            var data = db.Biddings.Where(f => f.PropertyId == pid).ToList(); ;
            return data;


        }

        public List<Bidding> Read()
        {
            return db.Biddings.ToList();
        }


        public Bidding Read(int id)
        {
            var data = db.Biddings.Where(b => b.PropertyId == id).OrderByDescending(b => b.BiddingAmount).FirstOrDefault();
            return data;
        }
        public List<Bidding> Read(string type)
        {
            var pid = Convert.ToInt32(type);
            var data = db.Biddings.Where(f => f.PropertyId == pid).ToList();
            return data;
        }

        public void Update(Bidding obj)
        {
            var exobj = Read(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
