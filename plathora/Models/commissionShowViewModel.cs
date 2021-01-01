using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class commissionShowViewModel
    {
        public string  Id { get; set; }         
        public int AffilatePackageid { get; set; }

        public string membershipName { get; set; }
        public string uniqueId { get; set; }
        public string registerbyAffilateID { get; set; }
        public string commissionAmount { get; set; }
        public string name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string createddate { get; set; }
    }
}
