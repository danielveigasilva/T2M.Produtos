using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using T2MProdutos.Models;
using System.Data.SqlClient;

namespace T2MProdutos.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductRepository productRepository;

        public ProductsController()
        {
            productRepository = new ProductRepository();
        }

        public IHttpActionResult GetAllProducts(int page = 0, int totalItens = 0)
        {
            try
            {
                if (totalItens <= 0)
                    return Ok(productRepository.GetAll());

                IEnumerable<Product> products = productRepository.GetAllPage(page, totalItens);
                if (products.Count() == 0)
                    return NotFound();

                var request = Request.CreateResponse<IEnumerable<Product>>(HttpStatusCode.OK, products);
                int totalPages = productRepository.GetTotalPages(totalItens);
                request.Headers.Add("X-Pagination-TotalPages", totalPages.ToString());

                string linkNextPage = null;
                if (page < totalPages)
                    linkNextPage = Request.RequestUri.ToString().Split('?')[0] + "?page=" + (page + 1) + "&totalItens=" + totalItens;
                request.Headers.Add("X-Pagination-NextPage", linkNextPage);

                return ResponseMessage(request);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult GetProduct(string Name)
        {
            try
            {
                Product product = productRepository.FindByName(Name);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult DeleteProduct(string Name)
        {
            try
            {
                bool delete = productRepository.DeleteByName(Name);
                if (!delete)
                    return NotFound();
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult PostProduct(Product product)
        {
            try
            {
                if (product.Name == null)
                    return BadRequest("Atributo Name Não Pode Ser Nulo");

                bool insert = productRepository.Insert(product);
                if (!insert)
                    return Conflict();

                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

    }
}
