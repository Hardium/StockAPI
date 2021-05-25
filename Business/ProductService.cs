using DataAccess;
using Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class ProductService : Service, IProductService
    {
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
        }

        /// <summary>
        /// Permet de récupérer l'ensemble des produits
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public Task<Product> GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }

        /// <summary>
        /// Permet d'ajouter le produit <paramref name="product"/> en base.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Task<Product> AddProductsAsync(Product product)
        {
            if (product.ValidFrom > product.ValidTo)
                throw new ArgumentException("La date de début ne peut être supérieur à la date de fin de validité du produit");

            return _repository.AddProductsAsync(product);
        }
    }
}
