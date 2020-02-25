using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T2MProdutos.Models
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAllPage(int page, int totalItens)
        {
            return DalHelper.GetAllProductsPage(page, totalItens);
        }

        public IEnumerable<Product> GetAll()
        {
            return DalHelper.GetAllProducts();
        }

        public int GetTotalPages(int totalItens)
        {
            return DalHelper.GetTotalPages(totalItens);
        }

        public Product FindByName(string Name)
        {
            return DalHelper.FindProductByName(Name);
        }

        public bool DeleteByName(string Name)
        {
            return DalHelper.DeleteProductByName(Name);
        }

        public bool Insert(Product product)
        {
            return DalHelper.InsertProduct(product);
        }

    }
}