namespace RepositoryCRUDOperations.Repositories
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get; }
        public Task <int> SaveChangesAsync();

    }
}
