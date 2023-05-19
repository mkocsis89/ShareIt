using Application.Core;
using Application.Posts.Dtos;
using Domain;
using MediatR;
using Persistence;

namespace Application.Posts
{
    public sealed class Details
    {
        public sealed class Query : IRequest<Result<PostDto>>
        {
            public Guid Id { get; set; }
        }

        public sealed class Handler : IRequestHandler<Query, Result<PostDto>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<PostDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.FindAsync(request.Id, cancellationToken);
                return Result<PostDto>.Success(post);
            }
        }
    }
}
