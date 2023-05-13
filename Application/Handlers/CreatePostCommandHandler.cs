using Application.Commands;
using MediatR;
using Persistence;

namespace Application.Handlers
{
    public sealed class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
    {
        private readonly DataContext _context;

        public CreatePostCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            // Adding the Post into memory, we are not touching SQL
            // (tracking the fact that we are adding an entity into memory)
            _context.Posts.Add(request.Post);
            await _context.SaveChangesAsync();
        }
    }
}
