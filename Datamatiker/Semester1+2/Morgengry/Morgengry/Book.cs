using System;
using System.Collections.Generic;
using System.Text;

namespace Morgengry
{
    public class Book : Merchandise
    {
        private string title;
        private double price;

        public Book(string itemId)
        {
            base.ItemId = itemId;
        }

        public Book(string itemId, string title)
        {
            base.ItemId = itemId;
            Title = title;
        }
        public Book(string itemId, string title, double price)
        {
            base.ItemId = itemId;
            Title = title;
            Price = price;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public override double GetValue()
        {
            return Price;
        }

        public override string ToString()
        {
            return "ItemId: " + ItemId + ", Title: " + Title + ", Price: " + Price;
        }
    }
}
