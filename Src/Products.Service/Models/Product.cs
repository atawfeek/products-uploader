using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Service.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public int ArtikelCode { get; set; }
        public string ColorCode { get; set; }   //to do: a separate lookup table for color codes.  should be Navigation Property
        public string Description { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public string DeliveredIn  { get; set; }  //to do: a separate lookup table for all possible delivery plans. should be Navigation Property
        public string TargetAge { get; set; }    //to do: should be lookup : baby, male, female, .. a navigation property
        public int Size { get; set; }
        public string Color { get; set; }   //should be lookup table for available colors.
    }
}
