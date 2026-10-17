using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace RepositoryCRUDOperations.DAL
{
    public class MyDataAccessContext : DbContext
    {
        public MyDataAccessContext(DbContextOptions<MyDataAccessContext> options) : base(options)
        {
        }
        public DbSet<Models.Product> Products { get; set; }
    }
}
