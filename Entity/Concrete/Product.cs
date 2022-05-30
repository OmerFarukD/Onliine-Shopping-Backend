using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstracts;

namespace Entity.Concrete
{
    public class Product :IEntity
    {
        public int ProductId { get; set; }
        public int  CategoryId { get; set; }
        public int ColorId { get; set; }

        public int ImageId { get; set; }

        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Description { get; set; }

    }
}
