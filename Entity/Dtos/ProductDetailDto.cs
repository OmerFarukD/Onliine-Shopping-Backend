using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstracts;

namespace Entity.Dtos
{
    public class ProductDetailDto :IDto
    {
        public string  ProductName { get; set; }

        public string CategoryName { get; set; }
        public string ColorName { get; set; }

        public double UnitPrice { get; set; }
        public int  UnitsInStock { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
