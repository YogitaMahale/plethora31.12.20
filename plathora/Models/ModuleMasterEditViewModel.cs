using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace plathora.Models
{
    public class ModuleMasterEditViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$"), Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [ Display(Name = "Amount")]
        public decimal amount { get; set; }


        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }

    }
}
