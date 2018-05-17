using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercise11_Inventory_System.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [StringLength(63, MinimumLength = 2, ErrorMessage = "Min 2, max 63")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(0, 65535, ErrorMessage = "Range 0 to 65535")]
        public int Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [StringLength(63, MinimumLength = 2, ErrorMessage = "Min 2, max 63")]
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [StringLength(63, MinimumLength = 2, ErrorMessage = "Min 2, max 63")]
        public string Shelf { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(0, 255, ErrorMessage = "Range 0 to 255")]
        public int Count { get; set; }

        [MaxLength(1023, ErrorMessage = "Max 1023")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(0, 255, ErrorMessage = "Range 0 to 255")]
        public int RestockLimit { get; set; }
    }
}