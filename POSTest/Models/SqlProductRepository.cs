using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTest.Models
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly AppDBContext context;

        public SqlProductRepository(AppDBContext context)
        {
            this.context = context;
        }
        public Product Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            Product product = context.Products.Find(id);
            if(product != null)
            {
                context.Products.Remove(product);
                 context.SaveChanges();
            }
            return product;
        }
        public Product GetProduct(int Id)
        {
            return context.Products.Find(Id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products;
        }

        public Product Update(Product productUpdated)
        {
            var product = context.Products.Attach(productUpdated);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return productUpdated;
        }
    }
}
