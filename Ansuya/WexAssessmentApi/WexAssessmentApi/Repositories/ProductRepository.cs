using WexAssessmentApi.Models;

namespace WexAssessmentApi.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository()
        {
            // Initialize with some mock data
            var mockProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.99M, Category = "Category 1", StockQuantity = 100 },
                new Product { Id = 2, Name = "Product 2", Price = 20.99M, Category = "Category 2", StockQuantity = 200 },
                new Product { Id = 3, Name = "Product 3", Price = 30.99M, Category = "Category 1", StockQuantity = 300 },
                new Product { Id = 4, Name = "Product 4", Price = 40.99M, Category = "Category 3", StockQuantity = 400 }
            };

            foreach (var product in mockProducts)
            {
                _store[product.Id] = product;
            }
        }
        public Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            var products = _store.Values.Where(p => p.Category == category);
            return Task.FromResult(products.AsEnumerable());
        }
    }
}
