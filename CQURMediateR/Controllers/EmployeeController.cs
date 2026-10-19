using CQURMediateR.Data.Command;
using CQURMediateR.Data.Handlers;
using CQURMediateR.Data.Query;
using CQURMediateR.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CQURMediateR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _mediator.Send(new GetEmployeeListQuery());
        }

        [HttpGet]
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });
        }

        [HttpPost]
        public async Task<Employee> AddEmployee(Employee employee)
        {
            return await _mediator.Send(new CreateEmployeeCommand(employee.Name, employee.Address, employee.Email, employee.Phone));
        }

        [HttpPut]
        public async Task<int> UpdateEmployee(int id, Employee employee)
        {
            return await _mediator.Send(new UpdateEmployeeCommand(id, employee.Name, employee.Address, employee.Email, employee.Phone));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _mediator.Send(new DeleteEmployeeCommand(id));
            return Ok();
        }

    }
}
