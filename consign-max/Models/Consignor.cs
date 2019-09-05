using System;
namespace consign_max.Models
{
    public class Consignor
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string FirstName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string MobilePhone { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public decimal Commission { get; set; }

    }
}
