using Domain;
using MediatR;

namespace Application.Queries
{
    public sealed class GetPostByIdQuery : IRequest<Post>
    {
        public Guid Id { get; set; }
    }
}
