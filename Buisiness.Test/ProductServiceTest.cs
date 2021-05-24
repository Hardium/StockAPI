using Business;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestClass()]
    public class ProductServiceTest
    {
        private static ProductService productService;

        readonly Product productWithValidDate = new() { ID = 8, Name = "productWithValidDate", EAN = "EAN12345", ValidFrom = new System.DateTime(2021, 02, 01), ValidTo = new System.DateTime(2021, 02, 15) };

        private const int ProductCount = 6;

        [ClassInitialize()]
        public static void ProductServiceTestInitialize(TestContext testContext)
        {

            //Initialize your Mock Data
            var options = new DbContextOptionsBuilder<StockContext>()
                .UseInMemoryDatabase(databaseName: "Stock")
                .Options;

            // Insert seed data into the database using one instance of the context
            var context = new StockContext(options);

            //Create the repository, service and add all fake products
            IProductRepository productRepository = new ProductRepository(context);
            productService = new ProductService(productRepository);

            var testDataProduct = new List<Product> {
                    new() { ID = 1, Name = "MockProduct1", EAN = "EAN02117", ValidFrom = new System.DateTime(2021, 02, 01), ValidTo = new System.DateTime(2021, 02, 15) },
                    new() { ID = 2, Name = "MockProduct2", EAN = "EAN02118", ValidFrom = new System.DateTime(2021, 02, 01), ValidTo = new System.DateTime(2021, 02, 15) },
                    new() { ID = 3, Name = "MockProduct3", EAN = "EAN02119", ValidFrom = new System.DateTime(2021, 02, 01), ValidTo = new System.DateTime(2021, 02, 15) },
                    new() { ID = 4, Name = "MockProduct4", EAN = "EAN02120", ValidFrom = new System.DateTime(2021, 02, 01), ValidTo = new System.DateTime(2021, 02, 15) },
                    new() { ID = 5, Name = "MockProduct5", EAN = "EAN02121", ValidFrom = new System.DateTime(2021, 02, 01), ValidTo = new System.DateTime(2021, 02, 15) },
                    new() { ID = 6, Name = "MockProduct6", EAN = "EAN02122", ValidFrom = new System.DateTime(2021, 02, 01), ValidTo = new System.DateTime(2021, 02, 15) }
                };
            testDataProduct.ForEach(p => productService.AddProductsAsync(p));

        }


        [TestMethod()]
        public void GetAllProducts()
        {
            var products = productService.GetAllProducts();
            Assert.IsTrue(products.Count() >= ProductCount);
        }

        [TestMethod()]
        public void GetProductById()
        {
            var product = productService.GetProductById(2);
            Assert.AreEqual(product.Result.ID, 2);
            Assert.AreEqual(product.Result.EAN, "EAN02118");
            Assert.AreEqual(product.Result.Name, "MockProduct2");
            Assert.AreEqual(product.Result.ValidFrom, new DateTime(2021, 02, 01));
            Assert.AreEqual(product.Result.ValidTo, new DateTime(2021, 02, 15));
            Assert.AreEqual(product.Result.CreationDate.Date, DateTime.Now.Date);
        }

        [TestMethod()]
        public void AddProducts_With_Good_Valid_DateAsync()
        {
            var insertedProduct = productService.AddProductsAsync(productWithValidDate);
            Assert.AreEqual(insertedProduct.Result, productWithValidDate);
        }

        [TestMethod()]
        public void AddProducts_With_Bad_Valid_Date()
        {
            var newProduct = new Product { Name = "BadProduct", EAN = "EAN12346", ValidFrom = new System.DateTime(2021, 02, 18), ValidTo = new System.DateTime(2021, 02, 15) };
            Assert.ThrowsException<ArgumentException>(() => productService.AddProductsAsync(newProduct));
        }
    }
}

