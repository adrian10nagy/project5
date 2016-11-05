﻿
using System.Collections.Generic;
namespace DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductType> ProductTypes { get; set; }
    }
}
