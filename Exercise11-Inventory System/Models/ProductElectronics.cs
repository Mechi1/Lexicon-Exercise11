using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise11_Inventory_System.Models
{
    public class ProductElectronics
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Shelf { get; set; }
        public int Count { get; set; }

        public ProductElectronics(int id, string name, int price, string shelf, int count)
        {
            Id = id;
            Name = name;
            Price = price;
            Shelf = shelf;
            Count = count;
        }
    }
}