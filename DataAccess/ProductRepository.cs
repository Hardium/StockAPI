using System;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(StockContext context)
            : base(context)
        {
        }

        /// <summary>
        ///     Permet de récuperer tous les produits
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        /// <summary>
        ///     Permet de récuperer un produit grace à son identifiant technique
        /// </summary>
        /// <returns></returns>
        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        /// <summary>
        ///     Permet d'ajout le produit <paramref name="product" />
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Retourn le produit ajouté</returns>
        public async Task<Product> AddProductsAsync(Product product)
        {
            //Date d'insertion en base
            product.CreationDate = DateTime.Now;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}