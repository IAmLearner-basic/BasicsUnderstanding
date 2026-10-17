using Microsoft.EntityFrameworkCore;
using RepositoryCRUDOperations.DAL;
using RepositoryCRUDOperations.Models;

namespace RepositoryCRUDOperations.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDataAccessContext _myDataAccessContext;
        public ProductRepository(MyDataAccessContext myDataAccessContext)
        {
            _myDataAccessContext = myDataAccessContext;
        }
        public async Task AddAsync(Product product)
        {
            _myDataAccessContext.Products.Add(product);
            await _myDataAccessContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _myDataAccessContext.Products.FindAsync(id);
            if (product != null)
            {
                _myDataAccessContext.Products.Remove(product);
                await _myDataAccessContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _myDataAccessContext.Products.ToListAsync();

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _myDataAccessContext.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _myDataAccessContext.Products.Update(product);
            await _myDataAccessContext.SaveChangesAsync();
        }
    }
}
