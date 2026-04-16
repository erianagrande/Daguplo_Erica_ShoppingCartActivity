using System;
using System.Collections.Generic;
using System.Text;

namespace Daguplo_Erica_ShoppingCartActivity
{
    internal class Product
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int RemainingStock { get; set; }

        // Constructor
        public Product(int id, string name, double price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            RemainingStock = stock;
        }

        // Display product details
        public void DisplayProduct()
        {
            Console.WriteLine($"{Id}. {Name} - \u20B1{Price} (Stock: {RemainingStock})");
        } 

        // Check if the stock is enough
        public bool HasEnoughStock(int quantity)
        {
            return quantity <= RemainingStock;
        }

        // Deduct Stock
        public void DeductStock(int quantity)
        {
            RemainingStock -= quantity;
        }

        // Compute total price for item 
        public double GetItemTotal(int quantity)
        {
            return Price * quantity;
        }
    }
    class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public double Total => Product.Price * Quantity;
    }
}
