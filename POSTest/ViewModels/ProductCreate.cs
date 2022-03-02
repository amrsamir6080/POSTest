using Microsoft.AspNetCore.Http;
using POSTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTest.ViewModels
{
    public class ProductCreate
    {
        public string Name { get; set; }
        //public string Size { get; set; }
        //[Required]
        public Sizes? Size { get; set; }
        //[Required]
        public float Price { get; set; }
        public IFormFile Photo { get; set; }
    }
}
