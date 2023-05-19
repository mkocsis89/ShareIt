using Application.Core;
using Application.Posts.Dtos;
using MediatR;
using Persistence;

namespace Application.Posts
{
    public sealed class Create
    {
        public sealed class Command : IRequest<Result<Unit>>
        {
            public PostDto Post { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Posts.Add(request.Post);
                var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (isSuccess)
                    return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Failed to create post");
            }
        }
    }
}
