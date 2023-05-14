using MediatR;

namespace Application.Commands
{
    public sealed class DeletePostCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
