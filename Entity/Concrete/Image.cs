using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Core.Entity.Abstracts;

namespace Entity.Concrete
{
    public class Image :IEntity
    {
        public int ImageId { get; set; }
        public  int ProductId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
