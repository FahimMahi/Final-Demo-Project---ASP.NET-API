using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Repos
{
    internal class PropertyRepo : Repo, IRepoPropertyBidding<Property, int>
    {
        public Property Create(Property obj)
        {
            db.Properties.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public List<Property> Delete(int id)
        {
            var exobj = Read(id);
            db.Properties.Remove(exobj);
            db.SaveChanges();
            var data = Read();
            return data;

        }


        public List<Property> Delete(int x, int y)
        {
            return new List<Property>();

        }
        public List<Property> Read()
        {
            return db.Properties.ToList();
        }

        public Property Read(int id)
        {
            return db.Properties.Find(id);
        }

        public List<Property> Read(string type)
        {
            var data = db.Properties.Where(f => f.Type == type).ToList();
            return data;
        }

        public void Update(Property obj)
        {
            var exobj = Read(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
        }
    }
}
