using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using POSTest.Models;
using POSTest.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace POSTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(IProductRepository productRepository , IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var model= _productRepository.GetAllProducts();
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        private string UploadedFile(ProductCreate model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        [HttpPost]
        public IActionResult Create(ProductCreate model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Product newproduct = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Size = model.Size,
                    PhotoPath = uniqueFileName
                };
                _productRepository.Add(newproduct);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Product product = _productRepository.GetProduct(id);
            ProductEdit productEdit = new ProductEdit
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ExistingPhotoPath = product.PhotoPath
            };
            return View(productEdit);
        }
        [HttpPost]
        public IActionResult Edit(ProductEdit model)
        {
            if (ModelState.IsValid)
            {
                Product product = _productRepository.GetProduct(model.Id);
                product.Name = model.Name;
                product.Price = model.Price;
                product.Size = model.Size;
                if(model.Photo != null)
                {
                    if(model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    product.PhotoPath = UploadedFile(model);
                }
                _productRepository.Update(product);
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var productToDelete =  _productRepository.GetProduct(id);
            if (productToDelete != null)
            {
                _productRepository.Delete(id);
            }
            return RedirectToAction("index");

        }
    }
}
