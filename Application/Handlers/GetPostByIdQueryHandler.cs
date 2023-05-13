using Application.Queries;
using Domain;
using MediatR;
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
            return await _context.Posts.FindAsync(request.Id, cancellationToken);
        }
    }
}
