using System;
using System.Web;
using System.Linq;
using System.Data.Odbc;
using NorthWind.Models;
using System.Data.OleDb;
using System.Collections.Generic;

namespace ConnectToDatabase1.Models
{
    public sealed class DbConnection
    {
        /* Declare lists */
        private static OleDbConnection aConnection = null;
        private List<Order> aListOfOrders = new List<Order>();
        private List<Shipper> aListOfShippers = new List<Shipper>();
        private List<Products> aListOfProducts = new List<Products>();
        private List<Customer> aListOfCustomers = new List<Customer>();
        private List<Employee> aListOfEmployees = new List<Employee>();
        private List<Category> aListOfCategories = new List<Category>();
        private List<Suppliers> aListOfSuppliers = new List<Suppliers>();
        private List<OrderDetail> aListOfOrderDetails = new List<OrderDetail>();
                       
        public static OleDbConnection Instance()
        {
            OleDbConnection myConnection;

            if (DbConnection.aConnection != null)
            {
                myConnection = DbConnection.aConnection;
            }
            else
            {
                myConnection = new OleDbConnection();
            }
            return myConnection;
        }

        public void InsertCategory(string categoryName, string descripion)
        {
            /* insert into the database */

            aConnection = DbConnection.Instance();

            string aSQL = "INSERT INTO Categories(CategoryName, Description) Values ('" + categoryName + "','" + descripion + "');";

            aConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Mohamed\Desktop\AlfredState\CISY2133\Northwind\Northwind.mdb;";
            aConnection.Open();

            OleDbCommand aCommand = aConnection.CreateCommand();
            aCommand.CommandText = aSQL;
            aCommand.ExecuteNonQuery(); // execute the command
            aConnection.Close();

        }

        public List<Suppliers> GetSuppliers()
        {
            string aSQL = "SELECT SupplierID, CompanyName, ContactName, ContactTitle," +
                "Address, City, Region, PostalCode, Country, Phone, Fax, HomePage FROM Suppliers;";

            aConnection = DbConnection.Instance();

            aConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Mohamed\Desktop\AlfredState\CISY2133\Northwind\Northwind.mdb;";

            aConnection.Open();

            OleDbCommand aCommand = aConnection.CreateCommand();

            aCommand.CommandText = aSQL;

            OleDbDataReader aReader = aCommand.ExecuteReader();

            // Read the data and store it in a list
            while (aReader.Read())
            {
                // create a new product 
                Suppliers aSupplier = new Suppliers();

                string aFax = Convert.ToString(aReader["Fax"]);
                string aCity = Convert.ToString(aReader["City"]);
                string aPhone = Convert.ToString(aReader["Phone"]);
                string aRegion = Convert.ToString(aReader["Region"]);
                string aAddress = Convert.ToString(aReader["Address"]);
                string aCountry = Convert.ToString(aReader["Country"]);
                string aHomePage = Convert.ToString(aReader["HomePage"]);
                int aSupplierID = Convert.ToInt32(aReader["SupplierID"]);
                string aPostalCode = Convert.ToString(aReader["PostalCode"]);
                string aContactName = Convert.ToString(aReader["ContactName"]);
                string aCompanyName = Convert.ToString(aReader["CompanyName"]);
                string aContactTitle = Convert.ToString(aReader["ContactTitle"]);
                          
                // assign to supplier object 
                aSupplier.Fax = aFax;
                aSupplier.City = aCity;
                aSupplier.Phone = aPhone;
                aSupplier.Region = aRegion;
                aSupplier.Address = aAddress;
                aSupplier.Country = aCountry;
                aSupplier.HomePage = aHomePage;
                aSupplier.SupplierID = aSupplierID;
                aSupplier.PostalCode = aPostalCode;
                aSupplier.ContactName = aContactName;
                aSupplier.CompanyName = aCompanyName;
                aSupplier.ContactTitle = aContactTitle;
               
                // add to supplier list 
                aListOfSuppliers.Add(aSupplier);
            }

            aConnection.Close();
            return aListOfSuppliers;
        }
        
        public List<OrderDetail> GetOrderDetails()
        {
            string aSQL = "SELECT OrderID, ProductID, UnitPrice, Quantity, Discount " +
                "FROM [Order Details];";

            aConnection = DbConnection.Instance();

            aConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Mohamed\Desktop\AlfredState\CISY2133\Northwind\Northwind.mdb;";

            aConnection.Open();

            OleDbCommand aCommand = aConnection.CreateCommand();

            aCommand.CommandText = aSQL;

            OleDbDataReader aReader = aCommand.ExecuteReader();

            // Read the data and store it in a list
            while (aReader.Read())
            {
                /* create a new product */
                OrderDetail aOrderDetail = new OrderDetail();

                int aOrderID = Convert.ToInt32(aReader["OrderID"]);
                int aQuantity = Convert.ToInt32(aReader["Quantity"]);
                int aDiscount = Convert.ToInt32(aReader["Discount"]);
                int aProductID = Convert.ToInt32(aReader["ProductID"]);
                double aUnitPrice = Convert.ToDouble(aReader["UnitPrice"]);

                /* assign to product object */
                aOrderDetail.OrderID = aOrderID;
                aOrderDetail.Quantity = aQuantity;
                aOrderDetail.Discount = aDiscount;
                aOrderDetail.ProductID = aProductID;
                aOrderDetail.UnitPrice = aUnitPrice;

                /* add to products list */
                aListOfOrderDetails.Add(aOrderDetail);
            }

            aConnection.Close();
            return aListOfOrderDetails;
        }

        public List<Customer> GetCustomers()
        {
            string aSQL = "SELECT CustomerID, CompanyName FROM Customers;"; // just getting what we need
            aConnection = DbConnection.Instance();

            aConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Mohamed\Desktop\AlfredState\CISY2133\Northwind\Northwind.mdb;";

            aConnection.Open();

            OleDbCommand aCommand = aConnection.CreateCommand();

            aCommand.CommandText = aSQL;

            OleDbDataReader aReader = aCommand.ExecuteReader();

            // Read the data and store it in a list
            while (aReader.Read())
            {
                /* create a new order */
                Customer aCustomer = new Customer();

                string aCustomerID = Convert.ToString(aReader["CustomerID"]);
                string aCompanyName = Convert.ToString(aReader["CompanyName"]);

                /* assign to customer object */
                aCustomer.CustomerID = aCustomerID;
                aCustomer.CompanyName = aCompanyName;

                /* add to customers list */
                aListOfCustomers.Add(aCustomer);
            }

            aConnection.Close();
            return aListOfCustomers;

        }

        public List<Employee> GetEmployees()
        {
            string aSQL = "SELECT EmployeeID, FirstName FROM Employees;"; // just getting what we need
            aConnection = DbConnection.Instance();

            aConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Mohamed\Desktop\AlfredState\CISY2133\Northwind\Northwind.mdb;";

            aConnection.Open();

            OleDbCommand aCommand = aConnection.CreateCommand();

            aCommand.CommandText = aSQL;

            OleDbDataReader aReader = aCommand.ExecuteReader();

            // Read the data and store it in a list
            while (aReader.Read())
            {
                /* create a new employee */
                Employee aEmployee = new Employee();

                int aEmployeeID = Convert.ToInt32(aReader["EmployeeID"]);
                string aFirstName = Convert.ToString(aReader["FirstName"]);

                /* assign to employee object */
                aEmployee.EmployeeID = aEmployeeID;
                aEmployee.Firstname = aFirstName;

                /* add to employee list */
                aListOfEmployees.Add(aEmployee);
            }

            aConnection.Close();
            return aListOfEmployees;
        }

        public List<Shipper> GetShippers()
        {

            string aSQL = "SELECT ShipperID, CompanyName FROM Shippers;"; // just getting what we need
            aConnection = DbConnection.Instance();

            aConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Mohamed\Desktop\AlfredState\CISY2133\Northwind\Northwind.mdb;";

            aConnection.Open();

            OleDbCommand aCommand = aConnection.CreateCommand();

            aCommand.CommandText = aSQL;

            OleDbDataReader aReader = aCommand.ExecuteReader();

            // Read the data and store it in a list
            while (aReader.Read())
            {
                /* create a new shipper */
                Shipper aShipper = new Shipper();

                int aShipperID = Convert.ToInt32(aReader["ShipperID"]);
                string aCompanyName = Convert.ToString(aReader["CompanyName"]);

                /* assign to customer object */
                aShipper.ShipperID = aShipperID;
                aShipper.CompanyName = aCompanyName;

                /* add to customers list */
                aListOfShippers.Add(aShipper);
            }

            aConnection.Close();
            return aListOfShippers;
        }

        public List<Order> GetOrders()
        {
            string aSQL = "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate," +
                "ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion," +
                "ShipPostalCode, ShipCountry FROM Orders;";

            aConnection = DbConnection.Instance();

            aConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Mohamed\Desktop\AlfredState\CISY2133\Northwind\Northwind.mdb;";

            aConnection.Open();

            OleDbCommand aCommand = aConnection.CreateCommand();

            aCommand.CommandText = aSQL;

            OleDbDataReader aReader = aCommand.ExecuteReader();

            // Read the data and store it in a list
            while (aReader.Read())
            {
                /* create a new order */
                Order aOrder = new Order();

                int aOrderID = Convert.ToInt32(aReader["OrderID"]);
                int aShipVia = Convert.ToInt32(aReader["ShipVia"]);
                double aFreight = Convert.ToDouble(aReader["Freight"]);
                string aShipCity = Convert.ToString(aReader["ShipCity"]);
                string aCustomerID = Convert.ToString(aReader["CustomerID"]);
                int aEmployeeID = Convert.ToInt32(aReader["EmployeeID"]);
                string aShipName = Convert.ToString(aReader["ShipName"]);
                string aShipRegion = Convert.ToString(aReader["ShipRegion"]);
                string aShipCountry = Convert.ToString(aReader["ShipCountry"]);
                DateTime aOrderDate = Convert.ToDateTime(aReader["OrderDate"]);
                string aShipAddress = Convert.ToString(aReader["ShipAddress"]);
                DateTime aRequiredDate = Convert.ToDateTime(aReader["RequiredDate"]);
                string aShipPostalCode = Convert.ToString(aReader["ShipPostalCode"]);
                DateTime aShippedDate = Convert.ToDateTime(aReader["ShippedDate"] == DBNull.Value ? "01/01/9999" : aReader["ShippedDate"]);
               
                /* assign to product object */
                aOrder.OrderID = aOrderID;
                aOrder.ShipVia = aShipVia;
                aOrder.Freight = aFreight;
                aOrder.ShipCity = aShipCity;
                aOrder.ShipName = aShipName;
                aOrder.OrderDate = aOrderDate;
                aOrder.CustomerID = aCustomerID;
                aOrder.EmployeeID = aEmployeeID;
                aOrder.ShipRegion = aShipRegion;
                aOrder.ShipCountry = aShipCountry;
                aOrder.ShipAddress = aShipAddress;
                aOrder.ShippedDate = aShippedDate;
                aOrder.RequiredDate = aRequiredDate;
                aOrder.ShipPostalCode = aShipPostalCode;

                /* add to orders list */
                aListOfOrders.Add(aOrder);
            }

            aConnection.Close();
            return aListOfOrders;
        }

        public List<Products> GetProducts()
        {
            string aSQL = "SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit," +
                "UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued FROM Products;";

            aConnection = DbConnection.Instance();

            aConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Mohamed\Desktop\AlfredState\CISY2133\Northwind\Northwind.mdb;";

            aConnection.Open();

            OleDbCommand aCommand = aConnection.CreateCommand();

            aCommand.CommandText = aSQL;

            OleDbDataReader aReader = aCommand.ExecuteReader();

            // Read the data and store it in a list
            while (aReader.Read())
            {
                /* create a new product */
                Products aProduct = new Products();
                
                int aProductID = Convert.ToInt32(aReader["ProductID"]);
                int aCategoryID = Convert.ToInt32(aReader["CategoryID"]);
                int aSupplierID = Convert.ToInt32(aReader["SupplierID"]);
                double aUnitPrice = Convert.ToDouble(aReader["UnitPrice"]);
                int aReorderLevel = Convert.ToInt32(aReader["ReorderLevel"]);
                int aUnitsOnOrder = Convert.ToInt32(aReader["UnitsOnOrder"]);
                int aUnitsInStock = Convert.ToInt32(aReader["UnitsInStock"]);
                string aProductName = Convert.ToString(aReader["ProductName"]);
                bool aDiscontinued = Convert.ToBoolean(aReader["Discontinued"]);
                string aQuantityPerUnit = Convert.ToString(aReader["QuantityPerUnit"]);

                /* assign to product object */
                aProduct.UnitPrice = aUnitPrice;
                aProduct.ProductID = aProductID;
                aProduct.SupplierID = aSupplierID;
                aProduct.CategoryID = aCategoryID;
                aProduct.ProductName = aProductName;
                aProduct.UnitsOnOrder = aUnitsOnOrder;
                aProduct.ReorderLevel = aReorderLevel;
                aProduct.UnitsInStock = aUnitsInStock;
                aProduct.Discontinued = aDiscontinued;
                aProduct.QuantityPerUnit = aQuantityPerUnit;                
               
                /* add to products list */
                aListOfProducts.Add(aProduct);
            }

            aConnection.Close();
            return aListOfProducts;
        }
        
        public List<Category> GetCategories()
        {

            aConnection = DbConnection.Instance();
            string aSQL = "SELECT CategoryId, CategoryName, Description FROM Categories;";
            aConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Mohamed\Desktop\AlfredState\CISY2133\Northwind\Northwind.mdb;";

            aConnection.Open();
            OleDbCommand aCommand = aConnection.CreateCommand();

            aCommand.CommandText = aSQL;
            OleDbDataReader aReader = aCommand.ExecuteReader();

            // Read the data and store it in a list
            while (aReader.Read())
            {
                
                int aCategoryId = (int)aReader["CategoryId"];
                string aCategoryName = (string)aReader["CategoryName"];
                string aDescription = (string)aReader["Description"];

                Category aCategory = new Category();

                aCategory.CategoryID = aCategoryId;
                aCategory.Description = aDescription;
                aCategory.CategoryName = aCategoryName;
                aListOfCategories.Add(aCategory);
                
            }

            aConnection.Close();
            return aListOfCategories;

        }
    }
}