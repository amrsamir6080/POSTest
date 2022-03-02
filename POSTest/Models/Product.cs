using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POSTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        //public string Size { get; set; }
        //[Required]
        public Sizes? Size { get; set; }
        //[Required]
        public float Price { get; set; }
        public string PhotoPath { get; set; }
    }
}
