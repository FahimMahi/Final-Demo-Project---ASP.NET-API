using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ComplainDTO
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime DateTime { get; set; }
        public int BuyerId { get; set; }
    }
}
