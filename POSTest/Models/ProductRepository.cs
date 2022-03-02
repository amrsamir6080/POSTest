using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTest.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _productList;
        public ProductRepository()
        {
            _productList = new List<Product>()
            {
                new Product(){Id = 1, Name ="BeefBurger", Price = 5, Size = Sizes.Small},
                new Product(){Id = 2, Name ="BeefBurger", Price = 7, Size = Sizes.Medium},
                new Product(){Id = 3, Name ="BeefBurger", Price = 9, Size = Sizes.Large}
            };
        }

        public Product GetProduct(int id)
        {
            return _productList.FirstOrDefault(p => p.Id == id);
        }
        public Product Add(Product product)
        {
            product.Id = _productList.Max(p => p.Id) + 1;
            _productList.Add(product);
            return product;
        }

        public Product Delete(int id)
        {
            Product product = _productList.FirstOrDefault(p => p.Id == id);
            if(product != null)
            {
                _productList.Remove(product);
            }
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productList;
        }

        public Product Update(Product productUpdated)
        {
            Product product = _productList.FirstOrDefault(p => p.Id == productUpdated.Id);
            if (product != null)
            {
                product.Name = productUpdated.Name;
                product.Price = productUpdated.Price;
                product.Size = productUpdated.Size;
            }
            return product;
        }
    }
}
