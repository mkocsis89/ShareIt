using Application.Core;
using Domain;
using MediatR;

namespace Application.Commands
{
    public sealed class CreatePostCommand : IRequest<Result<Unit>>
    {
        public Post Post { get; set; }
    }
}
