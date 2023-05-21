using Application.Core;
using Application.Dtos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Posts
{
    public sealed class Details
    {
        public sealed class Query : IRequest<Result<PostDto>>
        {
            public Guid Id { get; set; }
        }

        public sealed class QueryHandler : IRequestHandler<Query, Result<PostDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public QueryHandler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PostDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.Include(p => p.Scores).FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
                var postDto = _mapper.Map<PostDto>(post);

                var postParts = _context.PostParts.Where(pp => pp.PostId == post.Id).Select(pp => pp.PartId).ToList();

                if (!postParts.Any())
                    return Result<PostDto>.Success(postDto);

                var specialParts = _context.SpecialParts.Where(p => postParts.Contains(p.DesignId));
                postDto.SpecialParts = specialParts.Select(p => new PartDto { DesignId = p.DesignId }).ToArray();
                return Result<PostDto>.Success(postDto);
            }
        }
    }
}
