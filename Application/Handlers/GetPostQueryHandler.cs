using Application.Core;
using Application.Queries;
using Domain;
using MediatR;
using Persistence;

namespace Application.Handlers
{
    public sealed class GetPostQueryHandler : IRequestHandler<GetPostQuery, Result<Post>>
    {
        private readonly DataContext _context;

        public GetPostQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Post>> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = await _context.LoadPostAsync(request.Id, cancellationToken);
            return Result<Post>.Success(post);
        }
    }
}
