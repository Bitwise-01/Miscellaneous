using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace NorthWind.Models
{
    public class Employee
    {
        private int reportsTO = -1;
        private string city = "n/a";
        private int employeeID = -1;
        private bool active = false;
        private string title = "n/a";
        private string notes = "n/a";
        private string region = "n/a";
        private string photo = "n/a";
        private string country = "n/a";
        private string address = "n/a";
        private string lastname = "n/a";
        private string hireDate = "n/a";
        private string birthDate = "n/a";
        private string firstname = "n/a";
        private string homePhone = "n/a";
        private string extension = "n/a";
        private string postalCode = "n/a";
        private string titleOfCourtesy = "n/a";

        public Employee()
        {
            /* pass */
        }

        public Employee(int employeeID, string lastname, string firstname, string title, string titleOfCourtesy, string birthDate,
                        string hireDate, string address, string city, string region, string postalCode, string country, string homePhone,
                        string extension, string photo, string notes, int reportsTO, bool active) : this()
        {
            this.City = city;
            this.Photo = photo;
            this.Notes = notes;
            this.Title = title;
            this.Region = region;
            this.Active = active;
            this.Address = address;
            this.Country = country;
            this.HireDate = hireDate;
            this.Lastname = lastname;
            this.Firstname = firstname;
            this.HomePhone = homePhone;
            this.BirthDate = birthDate;
            this.Extension = extension;
            this.ReportsTO = reportsTO;
            this.PostalCode = postalCode;
            this.EmployeeID = employeeID;
            this.TitleOfCourtesy = titleOfCourtesy;
        }

        public int EmployeeID
        {
            get { return this.employeeID; }
            set { this.employeeID = value; }
        }

        public string Lastname
        {
            get { return this.lastname; }
            set { this.lastname = value; }
        }

        public string Firstname
        {
            get { return this.firstname; }
            set { this.firstname = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string TitleOfCourtesy
        {
            get { return this.titleOfCourtesy; }
            set { this.titleOfCourtesy = value; }
        }

        public string BirthDate
        {
            get { return this.birthDate; }
            set { this.birthDate = value; }
        }

        public string HireDate
        {
            get { return this.hireDate; }
            set { this.hireDate = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }

        public string Region
        {
            get { return this.region; }
            set { this.region = value; }
        }

        public string PostalCode
        {
            get { return this.postalCode; }
            set { this.postalCode = value; }
        }

        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }

        public string HomePhone
        {
            get { return this.homePhone; }
            set { this.homePhone = value; }
        }

        public string Extension
        {
            get { return this.extension; }
            set { this.extension = value; }
        }

        public string Photo
        {
            get { return this.photo; }
            set { this.photo = value; }
        }

        public string Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }

        public int ReportsTO
        {
            get { return this.reportsTO; }
            set { this.reportsTO = value; }
        }

        public bool Active
        {
            get { return this.active; }
            set { this.active = value; }
        }
        
        public override string ToString()
        {
            return "<br/>EmployeeID: " + this.EmployeeID
                + "<br/>Firstname: " + this.Firstname
                + "<br/>Lastname: " + this.Lastname
                + "<br/>Title: " + this.Title
                + "<br/>TitleOfCourtesy: " + this.TitleOfCourtesy
                + "<br/>BirthDate: " + this.BirthDate
                + "<br/>HireDate: " + this.HireDate
                + "<br/>Address: " + this.Address
                + "<br/>City: " + this.City
                + "<br/>Region: " + this.Region
                + "<br/>PostalCode: " + this.PostalCode
                + "<br/>Country: " + this.Country
                + "<br/>HomePhone: " + this.HomePhone
                + "<br/>Extension: " + this.Extension
                + "<br/>Photo: " + this.Photo
                + "<br/>Notes: " + this.Notes
                + "<br/>ReportsTO: " + this.ReportsTO
                + "<br/>isActive: " + this.Active
                + "<br/>";
        }
    }
}