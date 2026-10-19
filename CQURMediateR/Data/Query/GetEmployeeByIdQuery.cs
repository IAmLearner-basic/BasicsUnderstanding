using CQURMediateR.Models;
using MediatR;

namespace CQURMediateR.Data.Query
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
