using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class MembershipCreateViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Membership Name")]
        public string membershipName { get; set; }
        [Display(Name = "GST")]
        public decimal gst { get; set; }
        public Boolean isdeleted { get; set; }
         
        public Boolean isactive { get; set; }
        public decimal amount { get; set; }


        public string period { get; set; }
    }
}
