using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2MProdutos.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllPage(int page, int totalItens);
        IEnumerable<Product> GetAll();
        int GetTotalPages(int totalItens);
        Product FindByName(string Name);
        bool DeleteByName(string Name);
        bool Insert(Product product);
    }
}
