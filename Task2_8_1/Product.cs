using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task2_8_1
{
    public enum ProductTypes
    {
        Food,
        Technic
    }
    public class Product
    {
        public string ProductName { get; set; }

        public decimal Cost { get; set; }

        public string ImageWay { get; set; }

        public ProductTypes ProductType { get; set; }

    }
}
