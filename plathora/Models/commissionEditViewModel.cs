using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class commissionEditViewModel
    {
        public int id { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal commissionper { get; set; }

       
    }
}
