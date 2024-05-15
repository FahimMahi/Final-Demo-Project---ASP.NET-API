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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
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
