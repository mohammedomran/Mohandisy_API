using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mohandisy.Models
{
    
    public class ServiceProviderProfile
    {
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        // INDIVIDUAL SERVICE PROVIDER
        public string MembershipNumber { get; set; }
        public string MembershipPath { get; set; }
        public string IdNumber { get; set; }
        public string IdPath { get; set; }
        public List<ServiceProviderWork> ServiceProviderWorks { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string StreetName { get; set; }
        public int BuildingNumber { get; set; }
        public int AdditionalNumber { get; set; }
        public string PostalBox { get; set; }
        public string PostalCode { get; set; }

        //EXTENDED ORGANIZATION SERVICE PROVIDER
        public int RepresentativeId { get; set; }
        public List<Employee> Employees { get; set; }
        public int ProjectServiceId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyRegisterationNumber { get; set; }
        public string CompanyRegisterationNumberPath { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseNumberPath { get; set; }
        public int CompanyClassificationId { get; set; }
        public string CompanyLogoPath { get; set; }
        public string YearlyBudget { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string OfficeMobileNumber { get; set; }
        public string WebsiteLink { get; set; }
    }
}
