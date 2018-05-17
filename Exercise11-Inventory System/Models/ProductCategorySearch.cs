using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise11_Inventory_System.Models
{
    public class ProductCategorySearch
    {
        public List<string> Categories { get; set; }

        public ProductCategorySearch(List<string> categories)
        {
            Categories = categories;
        }
    }
}