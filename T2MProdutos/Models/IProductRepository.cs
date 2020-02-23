using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2MProdutos.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product FindByName(string Name);
        void Insert(Product item);
        void Delete(string Name);
    }
}
