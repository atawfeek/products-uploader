using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain
{
    public class ProductDomain
    {
        public string Key { get; set; }
        public int ArtikelCode { get; set; }
        public string ColorCode { get; set; }  
        public string Description { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public string DeliveredIn { get; set; } 
        public string TargetAge { get; set; }   
        public int Size { get; set; }
        public string Color { get; set; }   
    }
}
