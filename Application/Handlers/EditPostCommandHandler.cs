using Application.Commands;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Handlers
{
    public sealed class EditPostCommandHandler : IRequestHandler<EditPostCommand>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EditPostCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(EditPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FindAsync(request.Post.Id);
            _mapper.Map(request.Post, post);
            await _context.SaveChangesAsync();
        }
    }
}
