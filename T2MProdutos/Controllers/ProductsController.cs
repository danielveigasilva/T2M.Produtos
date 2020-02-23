using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using T2MProdutos.Models;

namespace T2MProdutos.Controllers
{
    public class ProductsController : ApiController
    {

        private static List<Product> products = new List<Product>();
        private ProductRepository productRepository;

        public ProductsController()
        {
            productRepository = new ProductRepository();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll();
        }

        public IHttpActionResult GetProduct(string name)
        {
            return Ok(productRepository.FindByName(name));
        }

        public IHttpActionResult PostProduct(Product product)
        {
            try
            {
                productRepository.Insert(product);
                return Ok("Produto Removido");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult DeleteProduct(string name)
        {
            try
            {
                productRepository.Delete(name);
                return Ok("Produto Removido");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
