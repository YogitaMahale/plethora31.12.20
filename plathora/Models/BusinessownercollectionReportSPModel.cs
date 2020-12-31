using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class BusinessownercollectionReportSPModel
    {

     //   id,MembershipId,customerName,membershipName,gstper,pkgamt,gstamt,PaymentAmount,Registrationdate
        public string  Id { get; set; }
        public string businessid { get; set; }
        public string name { get; set; }
        public string PhoneNumber { get; set; }
        public string createddate { get; set; }

        public string BusinessPackageId { get; set; }
        public string pkgname { get; set; }
        public decimal gst { get; set; }
        public decimal gstAmount { get; set; }




        public decimal PackageAmount { get; set; }
        public decimal commissionper { get; set; }
        public decimal commission1 { get; set; }
        public decimal tds { get; set; }
        public decimal commissionAmount { get; set; }

        public decimal PaymentAmount { get; set; }
        public decimal plethoraamt { get; set; }
       

        //  Id businessid  name PhoneNumber createddate BusinessPackageId   pkgname gst gstAmount AffilatePackageAmount

        //commissionper commission1 tds commissionAmount    PaymentAmount plethoraamt

    }
}
