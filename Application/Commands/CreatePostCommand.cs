using Domain;
using MediatR;

namespace Application.Commands
{
    public sealed class CreatePostCommand : IRequest
    {
        public Post Post { get; set; }
    }
}
