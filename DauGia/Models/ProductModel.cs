using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace DauGia.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public byte Type { get; set; }
        public int Quantity { get; set; }
        public DateTime TimeUpdate { get; set; }
        public byte Status { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }

        //public virtual ProductStatus ProductStatu { get; set; }
        //public virtual ProductType ProductType { get; set; }
        //public virtual User User { get; set; }
        //public virtual ProductDetail ProductDetail { get; set; }
    }
}