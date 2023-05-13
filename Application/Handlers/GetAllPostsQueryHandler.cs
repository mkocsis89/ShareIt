using Application.Queries;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Handlers
{
    public sealed class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, List<Post>>
    {
        private readonly DataContext _context;

        public GetAllPostsQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Posts.ToListAsync(cancellationToken);
        }
    }
}
