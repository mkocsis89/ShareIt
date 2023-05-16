using Application.Core;
using Domain;
using MediatR;

namespace Application.Queries
{
    public sealed class GetPostQuery : IRequest<Result<Post>>
    {
        public Guid Id { get; set; }
    }
}
