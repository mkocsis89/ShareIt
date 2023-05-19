using Application.Core;
using Application.Posts.Dtos;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Posts
{
    public sealed class List
    {
        public sealed class Query : IRequest<Result<List<PostDto>>>
        {
        }

        public sealed class Handler : IRequestHandler<Query, Result<List<PostDto>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<PostDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var posts = await _context.Posts.ToListAsync(cancellationToken);
                return Result<List<Post>>.Success(posts);
            }
        }
    }
}
