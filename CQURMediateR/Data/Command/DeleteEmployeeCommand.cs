using MediatR;

namespace CQURMediateR.Data.Command
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
