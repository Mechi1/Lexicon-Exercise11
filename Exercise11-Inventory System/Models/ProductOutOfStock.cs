using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise11_Inventory_System.Models
{
    public class ProductOutOfStock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public ProductOutOfStock(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}