using Domain;
using MediatR;

namespace Application.Commands
{
    // Commands do not return anything (fundamental difference between querys and commands)
    public sealed class CreatePostCommand : IRequest
    {
        public Post Post { get; set; }
    }
}
