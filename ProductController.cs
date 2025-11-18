using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstProducts.Data;
using CodeFirstProducts.Data.Models;

namespace CodeFirstProducts.Buisness
{
    public class ProductController
    {
        private ShopDbContext _shopDbContext;

        public ProductController()
        {
            _shopDbContext = new ShopDbContext();
        }
        public List<Product> GetAll()
        {
            return _shopDbContext.Products.ToList();
        }
        public Product Get(int id)
        {
            Product product = _shopDbContext
                .Products
                .FirstOrDefault(p => p.Id == id);
            return product;

        }
        public void Update(Product product)
        {
            Product productItem = this.Get(product.Id);

            this._shopDbContext
                .Entry(productItem)
                .CurrentValues
                .SetValues(product);
            _shopDbContext .SaveChanges();
        }
        public void Delete(int id)
        {
            Product productItem = this.Get(id);
            _shopDbContext.Products.Remove(productItem);
            _shopDbContext.SaveChanges();
        }
        public void Add(Product product)
        {
            _shopDbContext.Products.Add(product);
            _shopDbContext.SaveChanges();
        }
    }
}
