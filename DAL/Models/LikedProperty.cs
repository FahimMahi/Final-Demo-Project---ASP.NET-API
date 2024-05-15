using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class LikedProperty
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }

        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Property Property { get; set; }
    }
}
