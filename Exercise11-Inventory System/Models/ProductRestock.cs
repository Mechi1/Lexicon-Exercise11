using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise11_Inventory_System.Models
{
    public class ProductRestock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Shelf { get; set; }
        public int Count { get; set; }
        public int RestockLimit { get; set; }

        public ProductRestock(int id, string name, string category, string shelf, int count, int restocklimit)
        {
            Id = id;
            Name = name;
            Category = category;
            Shelf = shelf;
            Count = count;
            RestockLimit = restocklimit;
        }
    }
}