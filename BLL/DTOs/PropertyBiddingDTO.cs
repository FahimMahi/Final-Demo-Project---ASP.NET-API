using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PropertyBiddingDTO : PropertyDTO
    {
        public List<BiddingDTO> Biddings { get; set; }

        public PropertyBiddingDTO()
        {
            Biddings = new List<BiddingDTO>();
        }
    }
}
