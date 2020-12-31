using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class AffilatePackageCreateModel
    {
        public int id { get; set; }
        [Display(Name = "Select Membership")]
        public int membershipid { get; set; }

        [Display(Name = "Select Commission")]
        public int commissionid { get; set; }
        
        [Required]
        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18, 2)")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal amount { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name ="GST")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal gst { get; set; }

        [Required]
        [Display(Name = "Affilate Amount")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal affilateamt { get; set; }
        [Required]
        [Display(Name = "Plethora Amount")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]

        public decimal plethoraamt { get; set; }



        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
