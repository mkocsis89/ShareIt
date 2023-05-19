using Application.Core;
using Application.Posts.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Posts
{
    public sealed class List
    {
        public sealed class Query : IRequest<Result<List<PostDto>>>
        {
        }

        public sealed class Handler : IRequestHandler<Query, Result<List<PostDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<PostDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var posts = await _context.Posts.ToListAsync(cancellationToken);
                return Result<List<PostDto>>.Success(posts.Select(_mapper.Map<PostDto>).ToList());
            }
        }
    }
}
