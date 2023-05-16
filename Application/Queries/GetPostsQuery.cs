using Application.Core;
using Domain;
using MediatR;

namespace Application.Queries
{
    public sealed class GetPostsQuery : IRequest<Result<List<Post>>>
    {
    }
}
