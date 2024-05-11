using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FavPropertyDTO:BuyerDTO
    {
        public List<PropertyDTO> Properties { get; set; }

        public FavPropertyDTO()
        {
            Properties = new List<PropertyDTO>();
        }

    }
}
