using Application.Core;
using Application.Queries;
using Domain;
using MediatR;
using Persistence;

namespace Application.Handlers
{
    public sealed class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, Result<List<Post>>>
    {
        private readonly DataContext _context;

        public GetPostsQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<List<Post>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _context.LoadPostsAsync(cancellationToken);
            return Result<List<Post>>.Success(posts);
        }
    }
}
