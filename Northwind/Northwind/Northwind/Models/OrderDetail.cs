using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace NorthWind.Models
{
    public class OrderDetail
    {
        private int orderID = -1;
        private int quantity = -1;
        private int discount = -1;
        private int productID = -1;
        private double unitPrice = -0.00;

        public OrderDetail()
        {
            /* pass */
        }

        public OrderDetail(int orderID, int productID, double unitPrice, int quantity, int discount):this()
        {
            this.OrderID = orderID;
            this.Quantity = quantity;
            this.Discount = discount;
            this.ProductID = productID;
            this.UnitPrice = unitPrice;
        }

        public int OrderID
        {
            get { return this.orderID; }
            set { this.orderID = value; }
        }

        public int ProductID
        {
            get { return this.productID; }
            set { this.productID = value; }
        }
        public double UnitPrice
        {
            get { return this.unitPrice; }
            set { this.unitPrice = value; }
        }
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }
        public int Discount
        {
            get { return this.discount; }
            set { this.discount = value; }
        }

        public override string ToString()
        {
            return "<br/>OrderID: " + this.OrderID
                + "<br/>ProductID: " + this.ProductID
                + "<br/>UnitPrice: " + this.UnitPrice
                + "<br/>Quantity: " + this.Quantity
                + "<br/>Discount: " + this.Discount
                + "<br/>";
        }
    }
}