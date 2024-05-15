using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Agreement
    {

        [Key]
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime DateTime { get; set; }


        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }



        public virtual Buyer Buyer { get; set; }


        [ForeignKey("Landlord")]
        public int LandlordId { get; set; }

        public virtual Landlord Landlord { get; set; }


        [ForeignKey("Property")]
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
