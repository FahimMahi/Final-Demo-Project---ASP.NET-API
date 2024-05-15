using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LikedPropertyDTO
    {
        public int ID { get; set; }
        public int PropertyId { get; set; }
        public int BuyerId { get; set; }

        public virtual BuyerDTO Buyer { get; set; }
        public virtual PropertyDTO Property { get; set; }
    }
}
