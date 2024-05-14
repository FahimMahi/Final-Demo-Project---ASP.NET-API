using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Bidding
    {
        public int Id { get; set; }
        public int BiddingAmount { get; set; }
        public DateTime TimeDuration { get; set; }


        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        
        [ForeignKey("Buyer")]
        public int BidderId { get; set; }
        
        
        public int BuyerID { get; set; }
        public virtual Buyer Buyer { get; set; }
        public virtual Property Property { get; set; }

    }
}
