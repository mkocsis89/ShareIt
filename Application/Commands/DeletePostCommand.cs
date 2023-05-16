using Application.Core;
using MediatR;

namespace Application.Commands
{
    public sealed class DeletePostCommand : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }
}
