using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTest.ViewModels
{
    public class ProductEdit : ProductCreate
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
