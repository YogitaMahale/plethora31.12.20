using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace plathora.Models
{
    public class AdvertiseEditViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Amount")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal Amount { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [Display(Name ="Period( Month )")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter Only Numbers")]
        public int period { get; set; }

        [Required]
        [Display(Name = "GST")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal gst { get; set; }
        [Display(Name = "Image")]
        public IFormFile img { get; set; }


        [Required]
        [Display(Name = "Affilate Amount")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal affilateamt { get; set; }
        [Required]
        [Display(Name = "Plethora Amount")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]

        public decimal plethoraamt { get; set; }


        public string  img1 { get; set; }
    }
}
