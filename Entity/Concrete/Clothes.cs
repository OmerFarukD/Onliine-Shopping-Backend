using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstracts;

namespace Entity.Concrete
{
    public class Clothes :IEntity
    {
        public long Id { get; set; }
        public string ClothesName { get; set; }
        public double UnitPrice { get; set; }

        public string Color { get; set; }

        public int UnitsInStock { get; set; }
    }
}
