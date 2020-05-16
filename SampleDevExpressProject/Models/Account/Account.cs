using System;

namespace SampleDevExpressProject.Models.Account
{
    public class Account
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Telephone { get; set; }
        public string TaxNumber { get; set; }
        public string TCKNumber { get; set; }
        public string Email { get; set; }
        public string WebAddress { get; set; }
        public string AccountType { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}