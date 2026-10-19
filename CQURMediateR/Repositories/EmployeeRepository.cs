using CQURMediateR.Data;
using CQURMediateR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQURMediateR.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyDataContext _context;
        public EmployeeRepository(MyDataContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var result = _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var result = await _context.Employees.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (result == null)
                throw new InvalidOperationException("Employee not found");
            return result;
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync();
        }
    }
}
