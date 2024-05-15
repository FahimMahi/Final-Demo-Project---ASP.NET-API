using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Token
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string TKey { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey("User")]
        public int userid { get; set; }
        public virtual User User { get; set; }
    }
}
