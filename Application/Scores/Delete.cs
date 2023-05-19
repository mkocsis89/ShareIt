using Application.Core;
using MediatR;
using Persistence;

namespace Application.Scores
{
    public sealed class Delete
    {
        public sealed class Command : IRequest<Result<Unit>>
        {
            public Guid PostId { get; set; }
            public Guid ScoreId { get; set; }
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
                var post = await _context.Posts.FindAsync(request.PostId);

                if (post == null)
                    return null;

                var score = post.Scores.FirstOrDefault(score => score.Id == request.ScoreId);

                if (score == null)
                    return null;

                post.Scores.Remove(score);
                var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (!isSuccess)
                    return Result<Unit>.Failure("Failed to delete score");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
