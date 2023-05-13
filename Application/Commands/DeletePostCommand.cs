using MediatR;

namespace Application.Commands
{
    // Commands do not return anything (fundamental difference between querys and commands)
    public sealed class DeletePostCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
