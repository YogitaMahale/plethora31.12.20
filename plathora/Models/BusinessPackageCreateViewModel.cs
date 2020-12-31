using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace plathora.Models
{
    public class BusinessPackageCreateViewModel
    {
        public int id { get; set; }


        [Required]
        [Display(Name = "Package Name")]
        public int pkgId { get; set; }

        [Required]

        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal Amount { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [Display(Name ="Period in Month")]
        public string period { get; set; }
        
        public Boolean isdeleted { get; set; }
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



        public Boolean isactive { get; set; }
    }
}
