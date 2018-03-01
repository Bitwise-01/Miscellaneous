using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace NorthWind.Models
{
    public class Products
    {
        private int productID = -1;
        private int supplierID = -1;
        private int categoryID = -1;
        private double unitPrice = -1;
        private int unitsInStock = -1;
        private int unitsOnOrder = -1;
        private int reorderLevel = -1;
        private bool discontinued = false;
        private string productName = "n/a";
        private string quantityPerUnit = "n/a";

        public int ProductID
        {
            get
            {
                return this.productID;
            }
            set
            {
                this.productID = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                this.productName = value;
            }
        }

        public int SupplierID
        {
            get
            {
                return this.supplierID;
            }
            set
            {
                this.supplierID = value;
            }
        }
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

        public string QuantityPerUnit
        {
            get
            {
                return this.quantityPerUnit;
            }
            set
            {
                this.quantityPerUnit = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return this.unitPrice;
            }
            set
            {
                this.unitPrice = value;
            }
        }

        public int UnitsInStock
        {
            get
            {
                return this.unitsInStock;
            }
            set
            {
                this.unitsInStock = value;
            }
        }

        public int UnitsOnOrder
        {
            get
            {
                return this.unitsOnOrder;
            }
            set
            {
                this.unitsOnOrder = value;
            }
        }

        public int ReorderLevel
        {
            get
            {
                return this.reorderLevel;
            }
            set
            {
                this.reorderLevel = value;
            }
        }

        public bool Discontinued
        {
            get
            {
                return this.discontinued;
            }
            set
            {
                this.discontinued = value;
            }
        }

        public Products()
        {  }

        public Products(int anID) : this()
        {
            this.UnitPrice = -1;
            this.SupplierID = -1;
            this.CategoryID = -1;
            this.ProductID = anID;
            this.UnitsInStock = -1;
            this.UnitsOnOrder = -1;
            this.ReorderLevel = -1;
            this.ProductName = "n/a";
            this.Discontinued = false;
            this.QuantityPerUnit = "n/a";
        }

        public Products(int anID, string aProdName) : this()
        {
            this.UnitPrice = -1;
            this.SupplierID = -1;
            this.CategoryID = -1;
            this.ProductID = anID;
            this.UnitsInStock = -1;
            this.UnitsOnOrder = -1;
            this.ReorderLevel = -1;
            this.Discontinued = false;
            this.QuantityPerUnit = "n/a";
            this.ProductName = aProdName;
        }

        public Products(int anID, string aProdName, int aSupID) : this()
        {
            this.UnitPrice = -1;
            this.CategoryID = -1;
            this.ProductID = anID;
            this.UnitsInStock = -1;
            this.UnitsOnOrder = -1;
            this.ReorderLevel = -1;
            this.SupplierID = aSupID;
            this.Discontinued = false;
            this.QuantityPerUnit = "n/a";
            this.ProductName = aProdName;
        }

        public Products(int anID, string aProdName, int aSupID, int aCatID) : this()
        {
            this.UnitPrice = -1;
            this.ProductID = anID;
            this.UnitsInStock = -1;
            this.UnitsOnOrder = -1;
            this.ReorderLevel = -1;
            this.CategoryID = aCatID;
            this.SupplierID = aSupID;
            this.Discontinued = false;
            this.QuantityPerUnit = "n/a";
            this.ProductName = aProdName;
        }

        public Products(int anID, string aProdName, int aSupID, int aCatID, string aQuanPerUnit) : this()
        {
            this.UnitPrice = -1;
            this.ProductID = anID;
            this.UnitsInStock = -1;
            this.UnitsOnOrder = -1;
            this.ReorderLevel = -1;
            this.SupplierID = aSupID;
            this.CategoryID = aCatID;
            this.Discontinued = false;
            this.ProductName = aProdName;
            this.QuantityPerUnit = aQuanPerUnit;
        }

        public Products(int anID, string aProdName, int aSupID, int aCatID, string aQuanPerUnit, int aUnPrice) : this()
        {
            this.ProductID = anID;
            this.UnitsInStock = -1;
            this.UnitsOnOrder = -1;
            this.ReorderLevel = -1;
            this.SupplierID = aSupID;
            this.CategoryID = aCatID;
            this.UnitPrice = aUnPrice;
            this.Discontinued = false;
            this.ProductName = aProdName;
            this.QuantityPerUnit = aQuanPerUnit;
        }

        public Products(int anID, string aProdName, int aSupID, int aCatID, string aQuanPerUnit, int aUnPrice, int aUnInStock) : this()
        {
            this.ProductID = anID;
            this.UnitsOnOrder = -1;
            this.ReorderLevel = -1;
            this.SupplierID = aSupID;
            this.CategoryID = aCatID;
            this.UnitPrice = aUnPrice;
            this.Discontinued = false;
            this.ProductName = aProdName;
            this.UnitsInStock = aUnInStock;
            this.QuantityPerUnit = aQuanPerUnit;
        }

        public Products(int anID, string aProdName, int aSupID, int aCatID, string aQuanPerUnit, int aUnPrice, int aUnInStock, int aUnOnOrder) : this()
        {
            this.ProductID = anID;
            this.ReorderLevel = -1;
            this.SupplierID = aSupID;
            this.CategoryID = aCatID;
            this.UnitPrice = aUnPrice;
            this.Discontinued = false;
            this.ProductName = aProdName;
            this.UnitsInStock = aUnInStock;
            this.UnitsOnOrder = aUnOnOrder;
            this.QuantityPerUnit = aQuanPerUnit;
        }

        public Products(int anID, string aProdName, int aSupID, int aCatID, string aQuanPerUnit, int aUnPrice, int aUnInStock, int aUnOnOrder, int aReorderLevel) : this()
        {
            this.ProductID = anID;
            this.SupplierID = aSupID;
            this.CategoryID = aCatID;
            this.Discontinued = false;
            this.UnitPrice = aUnPrice;
            this.ProductName = aProdName;
            this.UnitsInStock = aUnInStock;
            this.UnitsOnOrder = aUnOnOrder;
            this.ReorderLevel = aReorderLevel;
            this.QuantityPerUnit = aQuanPerUnit;
        }
        public Products(int anID, string aProdName, int aSupID, int aCatID, string aQuanPerUnit, int aUnPrice, int aUnInStock, int aUnOnOrder, int aReorderLevel, bool aDesc) : this()
        {
            this.ProductID = anID;
            this.SupplierID = aSupID;
            this.CategoryID = aCatID;
            this.Discontinued = aDesc;
            this.UnitPrice = aUnPrice;
            this.ProductName = aProdName;
            this.UnitsInStock = aUnInStock;
            this.UnitsOnOrder = aUnOnOrder;
            this.ReorderLevel = aReorderLevel;
            this.QuantityPerUnit = aQuanPerUnit;
        }

        public override string ToString()
        {
            string message = "";
            message = message + "ProductID: " + this.ProductID + "<br />";
            message = message + "ProductName: " + this.ProductName + "<br />";
            message = message + "SupplierID: " + this.SupplierID + "<br />";
            message = message + "CategoryID: " + this.CategoryID + "<br />";
            message = message + "QuantityPerUnit: " + this.QuantityPerUnit + "<br />";
            message = message + "UnitPrice: " + this.UnitPrice + "<br />";
            message = message + "UnitsInStock: " + this.UnitsInStock + "<br />";
            message = message + "UnitsOnOrder: " + this.UnitsOnOrder + "<br />";
            message = message + "ReorderLevel: " + this.ReorderLevel + "<br />";
            message = message + "Discontinued: " + this.Discontinued + "<br />";

            return message;
        }

    }
}