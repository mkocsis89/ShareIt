using Application.Commands;
using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Handlers
{
    public sealed class EditPostCommandHandler : IRequestHandler<EditPostCommand, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EditPostCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(EditPostCommand request, CancellationToken cancellationToken)
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
