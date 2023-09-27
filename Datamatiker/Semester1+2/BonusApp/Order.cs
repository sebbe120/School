using System;
using System.Collections.Generic;
using System.Text;

namespace BonusApp
{
    public class Order
    {
        BonusProvider bonus;
        private List<Product> products = new List<Product>();

        public BonusProvider Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        public List<Product> Products
        {
            get { return products; }
        }

        public void AddProduct(Product p)
        {
            products.Add(p);
        }

        public double GetValueOfProducts()
        {
            double price = 0;

            foreach (Product product in products)
            {
                price += product.Price;
            }

            return price;
        }

        public double GetBonus()
        {
            double total = 0;

            foreach (Product product in products)
            {
                total += product.Price;
            }

            total = Bonus(total);

            return total;
        }

        public double GetTotalPrice()
        {
            double total = 0;

            foreach (Product product in products)
            {
                total += product.Price;
            }

            total -= Bonus(total);

            return total;
        }
    }
}
