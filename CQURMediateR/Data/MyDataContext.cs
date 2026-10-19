using CQURMediateR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQURMediateR.Data
{
    public class MyDataContext : DbContext
    {
        public MyDataContext(DbContextOptions<MyDataContext> options)
            : base(options) 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
