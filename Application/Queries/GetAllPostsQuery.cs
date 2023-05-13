using Domain;
using MediatR;

namespace Application.Queries
{
    public sealed class GetAllPostsQuery : IRequest<List<Post>>
    {
    }
}
