using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWind.Models
{
    public class Customer
    {
        private string fax = "n/a";
        private string city = "n/a";
        private string phone = "n/a";
        private string region = "n/a";
        private string country = "n/a";
        private string address = "n/a";
        private string customerID = "n/a";
        private string postalCode = "n/a";
        private string contactName = "n/a";
        private string companyName = "n/a";
        private string contactTitle = "n/a";

        public Customer()
        {
            /* pass */
        }

        public Customer(string fax, string city, string phone, string region, string country, string address, string customerID, 
                        string postalCode, string contactName, string companyName, string contactTitle) : this()
        {
            this.Fax = fax;
            this.City = city;
            this.Phone = phone;
            this.Region = region;
            this.Country = country;
            this.Address = address;
            this.CustomerID = customerID;
            this.PostalCode = postalCode;
            this.ContactName = contactName;
            this.CompanyName = companyName;
            this.ContactTitle = contactName;
        }

        public string Fax { get { return this.fax; } set { this.fax = value; } }
        public string City { get { return this.city; } set { this.city = value; } }
        public string Phone { get { return this.phone; } set { this.phone = value; } }
        public string Region { get { return this.region; } set { this.region = value; } }
        public string Country { get { return this.country; } set { this.country = value; } }
        public string Address { get { return this.address; } set { this.address = value; } }
        public string CustomerID { get { return this.customerID; } set { this.customerID = value; } }
        public string PostalCode { get { return this.postalCode; } set { this.postalCode = value; } }
        public string ContactName { get { return this.contactName; } set { this.contactName = value; } }
        public string CompanyName { get { return this.companyName; } set { this.companyName = value; } }
        public string ContactTitle { get { return this.contactName; } set { this.contactTitle = value; } }

        public override string ToString()
        {
            return "<br/>Fax: " + this.Fax
                + "<br/>City: " + this.City
                + "<br/>Phone: " + this.Phone
                + "<br/>Region: " + this.Region
                + "<br/>Country: " + this.Country
                + "<br/>Address: " + this.Address
                + "<br/>CustomerID: " + this.CustomerID
                + "<br/>PostalCode: " + this.PostalCode
                + "<br/>ContactName: " + this.ContactName
                + "<br/>CompanyName: " + this.CompanyName
                + "<br/>ContactTitle: " + this.ContactTitle
                + "<br/>";
        }
    }
}