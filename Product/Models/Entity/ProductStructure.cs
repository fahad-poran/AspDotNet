using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product.Models.Entity
{
    public class ProductStructure
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide name")]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}