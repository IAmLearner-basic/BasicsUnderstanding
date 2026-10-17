using RepositoryCRUDOperations.DAL;

namespace RepositoryCRUDOperations.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDataAccessContext _myDataAccessContext;
        public IProductRepository productRepository { get; private set; }
        public UnitOfWork(MyDataAccessContext myDataAccessContext)
        {
            _myDataAccessContext = myDataAccessContext;
            productRepository = new ProductRepository(_myDataAccessContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return _myDataAccessContext.SaveChangesAsync();
        }
    }
}
