using Application.Core;
using Application.Dtos;
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
                var posts = await _context.Posts.Include(p => p.Scores).ToListAsync(cancellationToken);
                return Result<List<PostDto>>.Success(posts.Select(post =>
                {
                    var postDto = _mapper.Map<PostDto>(post);
                    var postParts = _context.PostParts.Where(pp => pp.PostId == post.Id).Select(pp => pp.PartId).ToList();

                    if (!postParts.Any())
                        return postDto;

                    var specialParts = _context.SpecialParts.Where(p => postParts.Contains(p.DesignId));
                    postDto.SpecialParts = specialParts.Select(p => new PartDto { DesignId = p.DesignId }).ToArray();
                    return postDto;
                }).ToList());
            }
        }
    }
}
