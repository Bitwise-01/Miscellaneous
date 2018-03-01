using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace NorthWind.Models
{
    public class Order
    {
        private int orderID = -1;
        private int shipVia = -1;
        private DateTime orderDate;
        private int employeeID = -1;
        private DateTime shippedDate;
        private DateTime requiredDate;
        private double freight = -0.00;
        private string shipName = "n/a";
        private string shipCity = "n/a";
        private string shipRegion = "n/a";
        private string customerID = "n/a";
        private string shipCountry = "n/a";
        private string shipAddress = "n/a";
        private string shipPostalCode = "n/a";

        public Order()
        {
            /* pass */
        }

        public Order(int orderID, int shipVia, double freight, string shipName, string shipCity, DateTime orderDate, int employeeID,
                      string customerID, string shipRegion, string shipCountry, string shipAddress, DateTime shippedDate, DateTime requiredDate, string shipPostalCode) : this()
        {
             this.OrderID = orderID;
             this.ShipVia = shipVia;
             this.Freight = freight;
             this.ShipName = shipName;
             this.ShipCity = shipCity;
             this.OrderDate = orderDate;
             this.EmployeeID = employeeID;
             this.ShipRegion = shipRegion;
             this.CustomerID = customerID;
             this.ShipAddress = shipAddress;
             this.ShippedDate = shippedDate;
             this.ShipCountry = shipCountry;
             this.RequiredDate = requiredDate;
             this.ShipPostalCode = shipPostalCode;
    }

        public int OrderID
        {
            get { return this.orderID; }
            set { this.orderID = value; }
        }

        public int ShipVia
        {
            get { return this.shipVia; }
            set { this.shipVia = value; }
        }

        public double Freight
        {
            get { return this.freight; }
            set { this.freight = value; }
        }

        public string ShipName
        {
            get { return this.shipName; }
            set { this.shipName = value; }
        }

        public string ShipCity
        {
            get { return this.shipCity; }
            set { this.shipCity = value; }
        }

        public DateTime OrderDate
        {
            get { return this.orderDate; }
            set { this.orderDate = value; }
        }

        public int EmployeeID
        {
            get { return this.employeeID; }
            set { this.employeeID = value; }
        }

        public string CustomerID
        {
            get { return this.customerID; }
            set { this.customerID = value; }
        }

        public string ShipRegion
        {
            get { return this.shipRegion; }
            set { this.shipRegion = value; }
        }

        public string ShipCountry
        {
            get { return this.shipCountry; }
            set { this.shipCountry = value; }
        }

        public string ShipAddress
        {
            get { return this.shipAddress; }
            set { this.shipAddress = value; }
        }

        public DateTime ShippedDate
        {
            get { return this.shippedDate; }
            set { this.shippedDate = value; }
        }

        public DateTime RequiredDate
        {
            get { return this.requiredDate; }
            set { this.requiredDate = value; }
        }

        public string ShipPostalCode
        {
            get { return this.shipPostalCode; }
            set { this.shipPostalCode = value; }
        }


        public override string ToString()
        {
            return "<br/>OrderID: " + OrderID
                + "<br/>ShipVia: " + ShipVia
                + "<br/>Freight: " + Freight
                + "<br/>ShipName: " + ShipName
                + "<br/>ShipCity: " + ShipCity
                + "<br/>OrderDate: " + OrderDate
                + "<br/>EmployeeID: " + EmployeeID
                + "<br/>CustomerID: " + CustomerID
                + "<br/>ShipRegion: " + ShipRegion
                + "<br/>ShipCountry: " + ShipCountry
                + "<br/>ShipAddress: " + ShipAddress
                + "<br/>ShippedDate: " + ShippedDate
                + "<br/>RequireDate: " + RequiredDate
                + "<br/>ShipPostalCode: " + ShipPostalCode
                + "<br/>";
        }

    }
}