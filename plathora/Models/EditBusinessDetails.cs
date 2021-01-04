using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class EditBusinessDetails
    {
        //        id, businessid, productid, lic, MondayOpen, MondayClose, TuesdayOpen, TuesdayClose, 
        //WednesdayOpen, WednesdayClose, ThursdayOpen, ThursdayClose, FridayOpen, FridayClose, SaturdayOpen, SaturdayClose
        //, SundayOpen, SundayClose,
        //, sliderimg1, sliderimg2, sliderimg3
        //, sliderimg4, sliderimg5, description, facebookLink, googleplusLink, instagramLink, linkedinLink, twitterLink,
        // youtubeLink,
        // , Website, cityid, companyName, gstno, house, landmark, latitude, longitude, street, zipcode, 
        // businessOperation,organization


        //        id, businessid, productid, lic,
        //, sliderimg1, sliderimg2, sliderimg3
        //, sliderimg4, sliderimg5, description, facebookLink, googleplusLink, instagramLink, linkedinLink, twitterLink,
        // youtubeLink,
        // , ,  , , , ,  ,  ,  ,  ,  , 
        // businessOperation,organization
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]

        public string companyName { get; set; }

        [Required]
        [Display(Name = "GST No")]

        public string gstno { get; set; }
        [Required]
        [Display(Name = "Web Site")]

        public string Website { get; set; }


        [Required]
        [Display(Name = "House")]

        public string house { get; set; }
        [Display(Name = "Landmark")]
        public string landmark { get; set; }
        [Display(Name = "Street")]
        public string street { get; set; }

        [Required]

        [Display(Name = "Country")]
        public int countryid { get; set; }
        [Required]
        [Display(Name = "State")]
        public int stateid { get; set; }
        [Required]
        [Display(Name = "City")]
        public int? cityid { get; set; }



        [Display(Name = "Zipcode")]
        public string zipcode { get; set; }

        [Display(Name = "Monday Open")]
        public string MondayOpen { get; set; }



        [Display(Name = "Monday Close")]
        public string MondayClose { get; set; }

        [Display(Name = "Tuesday Open")]
        public string TuesdayOpen { get; set; }
        [Display(Name = "Tuesday Close")]
        public string TuesdayClose { get; set; }
        [Display(Name = "Wednesday Open")]
        public string WednesdayOpen { get; set; }



        [Display(Name = "Wednesday Close")]
        public string WednesdayClose { get; set; }

        [Display(Name = "Thursday Open")]
        public string ThursdayOpen { get; set; }
        [Display(Name = "Thursday Close")]
        public string ThursdayClose { get; set; }
        [Display(Name = "Friday Open")]
        public string FridayOpen { get; set; }
        [Display(Name = "Friday Close")]
        public string FridayClose { get; set; }
        [Display(Name = "Saturday Open")]
        public string SaturdayOpen { get; set; }


        [Display(Name = "Saturday Close")]
        public string SaturdayClose { get; set; }
        [Display(Name = "Sunday Open")]
        public string SundayOpen { get; set; }


        [Display(Name = "Sunday Close")]
        public string SundayClose { get; set; }

        [Display(Name = "sliderimg1")]
        public IFormFile sliderimg1 { get; set; }
        public string sliderimg11 { get; set; }

        [Display(Name = "sliderimg2")]
        public IFormFile sliderimg2 { get; set; }
        public string sliderimg21 { get; set; }
        [Display(Name = "sliderimg3")]
        public IFormFile sliderimg3 { get; set; }
        public string sliderimg31 { get; set; }
        [Display(Name = "sliderimg4")]
        public IFormFile sliderimg4 { get; set; }
        public string sliderimg41 { get; set; }
        [Display(Name = "sliderimg5")]
        public IFormFile sliderimg5 { get; set; }
        public string sliderimg51 { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }


        //, , , 
        //, , , , , , , , ,

        [Display(Name = "Facebook Link")]
        public string facebookLink { get; set; }

        [Display(Name = "Googleplus Link")]
        public string googleplusLink { get; set; }
        [Display(Name = "Instagram Link")]
        public string instagramLink { get; set; }
        [Display(Name = "Linkedin Link")]
        public string linkedinLink { get; set; }
        [Display(Name = "Twitter Link")]
        public string twitterLink { get; set; }

        [Display(Name = "Youtube Link")]
        public string youtubeLink { get; set; }

        


        [Display(Name = "Licenece")]
        public string lic { get; set; }
        [Display(Name = "Organization")]
        public string organization { get; set; }

    }
}
