using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T2MProdutos.Models
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            return DalHelper.GetAllProducts();
        }

        public void Delete(string Name)
        {
            DalHelper.DeleteProduct(Name);
        }

        public Product FindByName(string Name)
        {
            return DalHelper.FindByName(Name);
        }

        public void Insert(Product product)
        {
            DalHelper.InsertProduct(product);
        }
    }
}