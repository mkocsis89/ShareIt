using Application.Commands;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Handlers
{
    public sealed class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result<Unit>>
    {
        private readonly DataContext _context;

        public CreatePostCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            _context.Posts.Add(request.Post);
            var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (isSuccess)
                return Result<Unit>.Success(Unit.Value);
         
            return Result<Unit>.Failure("Failed to create post");
        }
    }
}
