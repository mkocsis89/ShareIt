using Application.Queries;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Handlers
{
    public sealed class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Post>
    {
        private readonly DataContext _context;

        public GetPostByIdQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Posts
                .Include(post => post.SpecialParts)
                .Include(post => post.Scores)
                .FirstOrDefaultAsync(post => post.Id == request.Id);
        }
    }
}
