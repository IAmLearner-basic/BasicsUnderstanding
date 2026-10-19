using CQURMediateR.Data.Command;
using CQURMediateR.Models;
using CQURMediateR.Repositories;
using MediatR;

namespace CQURMediateR.Data.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                Phone = request.Phone
            };
            await _employeeRepository.AddEmployeeAsync(employee);
            return employee;
        }
    }
}
