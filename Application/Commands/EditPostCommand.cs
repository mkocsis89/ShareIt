using Domain;
using MediatR;

namespace Application.Commands
{
    public sealed class EditPostCommand : IRequest
    {
        public Post Post { get; set; }
    }
}
