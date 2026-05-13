using System;
using System.Collections.Generic;
using System.Text;

namespace Daguplo_Erica_ShoppingCartActivity
{
    internal class Product
    {
        // Properties
        private int id;
        private string name;
        private double price;
        private int remainingStock;

        // Constructor
        public Product(int id, string name, double price, int stock)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.remainingStock = stock;
        }

        public void SetName(string name) 
        { 
            this.name = name;
        }

        public string GetName() 
        { 
            return this.name; 
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return this.id;
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }

        public double GetPrice()
        {
            return this.price;
        }
        public void SetRemainingStock(int remainingStock)
        {
            this.remainingStock = remainingStock;
        }

        public int GetRemainingStock()
        {
            return this.remainingStock;
        }

        // DISPLAY PRODUCT DETAILS

        public void DisplayProduct()
        {
            Console.WriteLine($"{id}. {name} - ₱{price} (Stock: {remainingStock})");
        }

        // CHECK IF STOCK IS ENOUGH

        public bool HasEnoughStock(int quantity)
        {
            return quantity <= remainingStock;
        }

        // DEDUCT STOCK

        public void DeductStock(int quantity)
        {
            remainingStock -= quantity;
        }

        // RESTOCK

        public void Restock(int quantity)
        {
            remainingStock += quantity;
        }

        // COMPUTE ITEM TOTAL

        public double GetItemTotal(int quantity)
        {
            return price * quantity;
        }
    }





}
