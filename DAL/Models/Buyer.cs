using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Buyer
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string address { get; set; }
        public int userid { get; set; }
        //public virtual ICollection<FavProperty> Properties { get; set; }

        //public Buyer()
        //{
        //    Properties = new List<FavProperty>();
        //}

    }
}
