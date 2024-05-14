using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Landlord")]
        public int LandLordId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public virtual Landlord Landlord { get; set; }
        public virtual ICollection<Bidding> Biddings { get; set; }
        public Property()
        {
            Biddings = new List<Bidding>();
        }
        //public virtual ICollection<FavProperty> Buyer { get; set; }


    }
}
