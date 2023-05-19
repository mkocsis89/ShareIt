using Application.Core;
using Application.Posts.Dtos;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Posts
{
    public sealed class Details
    {
        public sealed class Query : IRequest<Result<PostDto>>
        {
            public Guid Id { get; set; }
        }

        public sealed class Handler : IRequestHandler<Query, Result<PostDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PostDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.FindAsync(request.Id, cancellationToken);
                var postDto = _mapper.Map<PostDto>(post);
                return Result<PostDto>.Success(postDto);
            }
        }
    }
}
