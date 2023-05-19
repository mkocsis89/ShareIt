using Application.Core;
using Application.Posts.Dtos;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Posts
{
    public sealed class Edit
    {
        public sealed class Command : IRequest<Result<Unit>>
        {
            public PostDto Post { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.FindAsync(request.Post.Id, cancellationToken);

                if (post == null)
                    return null;

                _mapper.Map(request.Post, post);

                var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (!isSuccess)
                    return Result<Unit>.Failure("Failed to update post");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
