using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    public interface IProductRepository : IRepository
    {
        IQueryable<Product> GetAllProducts();

        Task<Product> GetProductById(int id);

        Task<Product> AddProductsAsync(Product product);
    }
}