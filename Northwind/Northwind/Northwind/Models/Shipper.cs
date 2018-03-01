using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWind.Models
{
    public class Shipper
    {
        private int shipperID = -1;
        private string phone = "n/a";
        private string companyName = "n/a";

        public Shipper()
        {
            /* pass */
        }

        public Shipper(int shipperID, string phone, string companyName) : this()
        {
            this.Phone = phone;
            this.ShipperID = shipperID;
            this.CompanyName = companyName;
        }

        public string Phone { get { return this.phone; } set { this.phone = value; } }
        public int ShipperID { get { return this.shipperID; } set { this.shipperID = value; } }
        public string CompanyName { get { return this.companyName; } set { this.companyName = value; } }

        public override string ToString()
        {
            return "<br/>ShipperID: " + this.Phone
                + "<br/>Phone: " + this.Phone
                + "<br/>CompanyName: " + this.CompanyName
                + "<br/>";
        }
    }
}