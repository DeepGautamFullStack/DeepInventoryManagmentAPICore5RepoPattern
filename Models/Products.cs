using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepInventoryManagmentAPICoreRepoPattern.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Make { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }


    }
}
