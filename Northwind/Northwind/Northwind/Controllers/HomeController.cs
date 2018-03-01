using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthWind.Models;
using ConnectToDatabase1.Models;
using System.Collections.Generic;

namespace ConnectToDatabase1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Insert Category
        public ActionResult InsertCategory(string categoryName, string description)
        {
            DbConnection aConnection = new DbConnection();
            aConnection.InsertCategory(categoryName, description);
            return View();
        }

        // GET: Category
        public ActionResult ChooseCategory(int CatID)
        {
            DbConnection aConnection = new DbConnection();
            List<Products> aListOfProducts = new List<Products>();

            List<Products> aListOfProductsByCategory = null;
            aListOfProducts = aConnection.GetProducts();

            // This is called Linq
            aListOfProductsByCategory = (from p in aListOfProducts
                                         where p.CategoryID == CatID
                                         select p).ToList();

            ViewBag.ChosenCatID = CatID;
            ViewBag.ListOfProductsByCategory = aListOfProductsByCategory;
            return View();
        }

        public ActionResult ChooseSupplier(int SupID)
        {

            DbConnection aConnection = new DbConnection();
            //List<Suppliers> aListOfSuppliers = new List<Suppliers>();
            List<Products> aListOfProducts = new List<Products>();

            //List<Suppliers> aListOfSuppliersByCategory = null;
            List<Products> aListOfProductsBySupplier = null;

            //aListOfSuppliers = aConnection.GetSuppliers();
            aListOfProducts = aConnection.GetProducts(); // One-to-many relationship; the supplierID is a foreign key in the products table

            // This is called Linq
            //aListOfSuppliersByCategory = (from p in aListOfSuppliers
            //                             where p.SupplierID == SupID
            //                             select p).ToList();

            aListOfProductsBySupplier = (from p in aListOfProducts
                                         where p.SupplierID == SupID
                                         select p).ToList();

            ViewBag.ChosenSupID = SupID;
            //ViewBag.ListOfSuppliersByCategory = aListOfSuppliersByCategory;
            ViewBag.ListOfProductsBySupplier = aListOfProductsBySupplier;
            return View();
                
        }

        // GET: OrderDetail 
        public ActionResult ChooseAProductForOrderDetails(int ProdID)
        {
            DbConnection aConnection = new DbConnection();
            List<OrderDetail> aListOfOrderDetails = new List<OrderDetail>();

            List<OrderDetail> aListOfOrderDetailsByProductID = null;
            aListOfOrderDetails = aConnection.GetOrderDetails(); // One-to-many relationship; the ProductID is a foreign key in the OrderDetail table

            // Linq
            aListOfOrderDetailsByProductID = (from p in aListOfOrderDetails
                                              where p.ProductID == ProdID
                                              select p).ToList();

            ViewBag.ChosenSupID = ProdID;
            ViewBag.aListOfOrderDetailsByProductID = aListOfOrderDetailsByProductID;
            return View();
        }

        // GET: Orders
        public ActionResult ChooseAnOrderIDForOrderDetails(int OrdID)
        {
            DbConnection aConnection = new DbConnection();
            List<OrderDetail> aListOfOrders = new List<OrderDetail>();
            
            List<OrderDetail> aListOfOrdersByOrderID = null;
            aListOfOrders = aConnection.GetOrderDetails();//GetOrders(); // One-to-many relationship; the OrderID is a foreign key in the OrderDetails table

            // Linq
            aListOfOrdersByOrderID = (from p in aListOfOrders
                                              where p.OrderID == OrdID
                                              select p).ToList();

            ViewBag.ChosenOrdID = OrdID;
            ViewBag.aListOfOrdersByOrderID = aListOfOrdersByOrderID;
            return View();
        }

        // GET: Customers 
        public ActionResult ChooseOrderByCustomerID(string CustID)
        {
            DbConnection aConnection = new DbConnection();
            List<Order> aListOfOrders = new List<Order>();

            List<Order> aListOfOrdersByCustomerID = null;
            aListOfOrders = aConnection.GetOrders(); // One-to-many relationship; the CustomerID is a foreign key in the Orders table

            // Linq
            aListOfOrdersByCustomerID = (from p in aListOfOrders
                                      where p.CustomerID == CustID
                                      select p).ToList();

            ViewBag.ChosenCustID = CustID;
            ViewBag.aListOfOrdersByCustomerID = aListOfOrdersByCustomerID;
            return View();
        }

        // GET: Employee
        public ActionResult ChooseOrderByEmployeeID(int EmplID)
        {
            DbConnection aConnection = new DbConnection();
            List<Order> aListOfOrders = new List<Order>();

            List<Order> aListOfOrdersByEmployeeID = null;
            aListOfOrders = aConnection.GetOrders(); // One-to-many relationship; the EmployeeID is a foreign key in the Orders table

            // Linq
            aListOfOrdersByEmployeeID = (from p in aListOfOrders
                                         where p.EmployeeID == EmplID
                                         select p).ToList();

            ViewBag.ChosenEmplID = EmplID;
            ViewBag.aListOfOrdersByEmployeeID = aListOfOrdersByEmployeeID;
            return View();
        }

        // GET: Shipper
        public ActionResult ChooseOrderByShipperID(int ShipID)
        {
            DbConnection aConnection = new DbConnection();
            List<Order> aListOfOrders = new List<Order>();

            List<Order> aListOfOrdersByShipperID = null;
            aListOfOrders = aConnection.GetOrders(); // One-to-many relationship; the EmployeeID is a foreign key in the Orders table

            // Linq
            aListOfOrdersByShipperID = (from p in aListOfOrders
                                         where p.ShipVia == ShipID
                                         select p).ToList();

            ViewBag.ChosenShipID = ShipID;
            ViewBag.aListOfOrdersByShipperID = aListOfOrdersByShipperID;
            return View();
        }
        
        // GET: Product  
        public ActionResult ChooseProduct(int ProdID)
        {
            ViewBag.ChosenProdID = ProdID;
            return View();
        }

        // GET: Home
        public ActionResult Index()
        {
            DbConnection aConnection = new DbConnection();
            List<Order> aListOfOrders = new List<Order>();
            List<Shipper> aListofShippers = new List<Shipper>();
            List<Products> aListOfProducts = new List<Products>();
            List<Customer> aListOfCustomers = new List<Customer>();
            List<Employee> aListOfEmployees = new List<Employee>();
            List<Category> aListOfCategories = new List<Category>();
            List<Suppliers> aListOfSuppliers = new List<Suppliers>();
            // List<OrderDetail> aListOfOrderDetails = new List<OrderDetail>(); // not needed

            aListOfOrders = aConnection.GetOrders();
            aListofShippers = aConnection.GetShippers();
            aListOfProducts = aConnection.GetProducts();
            aListOfCustomers = aConnection.GetCustomers();
            aListOfEmployees = aConnection.GetEmployees();
            aListOfSuppliers = aConnection.GetSuppliers();
            aListOfCategories = aConnection.GetCategories();
           // aListOfOrderDetails = aConnection.GetOrderDetails(); // not needed

            ViewBag.ListOfOrders = aListOfOrders;
            ViewBag.ListOfShippers = aListofShippers;
            ViewBag.ListOfProducts = aListOfProducts;
            ViewBag.ListofCustomers = aListOfCustomers;
            ViewBag.ListOfSuppliers = aListOfSuppliers;
            ViewBag.ListOfEmployees = aListOfEmployees;
            ViewBag.ListOfCategories = aListOfCategories;
           // ViewBag.ListOfOrderDetails = aListOfOrderDetails; // not needed
            return View();
        }

        public ActionResult ListProducts()
        {
            List<Products> aListOfProducts = new List<Products>();
            DbConnection aConnection = new DbConnection();
            aListOfProducts = aConnection.GetProducts();
            ViewBag.ListOfProducts = aListOfProducts;
            return View();
        }

        public ActionResult ProductDetails(int id)
        {
            List<Products> aListOfProducts = new List<Products>();
            DbConnection aConnection = new DbConnection();
            aListOfProducts = aConnection.GetProducts();
            var selectedProducts = from c in aListOfProducts
                                     where c.CategoryID == id
                                     select c;

            ViewBag.ListOfProducts = selectedProducts;
            return View();
        }

        public ActionResult ListCategories()
        {
            List<Category> aListOfCategories = new List<Category>();

            DbConnection aConnection = new DbConnection();
            aListOfCategories = aConnection.GetCategories();
            ViewBag.ListOfCategories = aListOfCategories;
            return View();
        }

        public ActionResult CategoryDetails(int id)
        {
            List<Category> aListOfCategories = new List<Category>();

            DbConnection aConnection = new DbConnection();

            aListOfCategories = aConnection.GetCategories();

            var selectedCategories = from c in aListOfCategories
                                     where c.CategoryID == id
                                     select c;


            ViewBag.ListOfCategories = selectedCategories;

            return View();
        }
    }
}


