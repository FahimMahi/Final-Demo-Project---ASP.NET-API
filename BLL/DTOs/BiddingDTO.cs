using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BiddingDTO
    {
        public int Id { get; set; }
        public int BiddingAmount { get; set; }
        //public DateTime TimeDuration { get; set; }
        public int PropertyId { get; set; }
        public int BidderId { get; set; }
        public int BuyerID { get; set; }
   
    }
}
