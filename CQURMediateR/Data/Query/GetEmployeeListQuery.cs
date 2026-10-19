using CQURMediateR.Models;
using MediatR;

namespace CQURMediateR.Data.Query
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    {
    }
}
