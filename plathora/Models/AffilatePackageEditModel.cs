using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class AffilatePackageEditModel
    {
        public int id { get; set; }

        public int membershipid { get; set; }


        public int commissionid { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal amount { get; set; }
        [Required]
        [Display(Name = "GST")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal gst { get; set; }
        public string Description { get; set; }


        [Required]
        [Display(Name = "Affilate Amount")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal affilateamt { get; set; }
        [Required]
        [Display(Name = "Plethora Amount")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]

        public decimal plethoraamt { get; set; }



    }
}
