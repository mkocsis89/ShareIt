using Application.Commands;
using MediatR;
using Persistence;

namespace Application.Handlers
{
    public sealed class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly DataContext _context;

        public DeletePostCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            // TODO Happy Path (error handlig), Validation
            var post = await _context.Posts.FindAsync(request.Id);
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
