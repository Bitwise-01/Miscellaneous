using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace NorthWind.Models
{
    public class Category
    {

        private int categoryID = -1;
        private string description = "n/a";
        private string categoryName = "n/a";
 
        public int CategoryID
        {
            get
            {
                return this.categoryID;
            }
            set
            {
                this.categoryID = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }
            set
            {
                this.categoryName = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
       
        public Category()
        {  }
        
        public Category(int anID) : this()
        {

            this.CategoryID = anID;
            this.CategoryName = "n/a";
            this.Description = "n/a";
        }

        public Category(int anID, string aCatName) : this()
        {
            this.CategoryID = anID;
            this.Description = "n/a";
            this.CategoryName = aCatName;
        }
        public Category(int anID, string aCatName, string aDesc) : this()
        {

            this.CategoryID = anID;
            this.Description = aDesc;
            this.CategoryName = aCatName;
        }

        public override string ToString()
        {
            string message = "";
            message = message + "CategoryID: " + this.CategoryID + "<br />";
            message = message + "Category Name: " + this.CategoryName + "<br />";
            message = message + "Description: " + this.Description + "<br />";
            return message;
        }
    }
}
