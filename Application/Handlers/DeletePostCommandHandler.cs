using Application.Commands;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Handlers
{
    public sealed class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Result<Unit>>
    {
        private readonly DataContext _context;

        public DeletePostCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FindAsync(request.Id);

            if (post == null)
                return null;

            _context.Remove(post);

            var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (!isSuccess)
                return Result<Unit>.Failure("Failed to delete post");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
