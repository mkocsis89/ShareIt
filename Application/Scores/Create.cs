using Application.Core;
using Application.Dtos;
using Domain;
using MediatR;
using Persistence;

namespace Application.Scores
{
    public sealed class Create
    {
        public sealed class Command : IRequest<Result<Unit>>
        {
            public Guid PostId { get; set; }
            public CreateScoreDto Score { get; set; }
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
                var post = _context.Posts.FirstOrDefault(post => post.Id == request.PostId);

                if (post == null)
                {
                    return null;
                }

                // TODO: after Users are implemented
                //var isScoreExsist = post.Scores.FirstOrDefault(score =>
                //    score.UserId == request.Score.UserId &&
                //    score.Type == request.Score.Type);

                post.Scores.Add(new Score { PostId = request.PostId, Type = request.Score.Type });

                var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (isSuccess)
                    return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Failed to add score");
            }
        }
    }
}
