using RepositoryCRUDOperations.Models;

namespace RepositoryCRUDOperations.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<Product?> GetProductByIdAsync(int id);
        public Task AddAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(int id);
    }
}
