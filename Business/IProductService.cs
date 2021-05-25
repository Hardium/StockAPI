using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Business
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProducts();

        Task<Product> GetProductById(int id);

        Task<Product> AddProductsAsync(Product product);
    }
}