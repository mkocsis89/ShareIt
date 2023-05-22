using Application.Core;
using Application.Dtos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
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
            private readonly ILogger<Handler> _logger;

            public Handler(DataContext context, IMapper mapper, ILogger<Edit.Handler> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.FindAsync(request.Post.Id, cancellationToken);

                if (post == null)
                    return null;

                Map(post, request.Post);

                var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (!isSuccess)
                    return Result<Unit>.Failure("Failed to update post");

                return Result<Unit>.Success(Unit.Value);
            }

            private void Map(Post post, PostDto dto)
            {
                _mapper.Map(dto, post);
                var postPartsToAdd = new List<PostPart>();

                foreach (var designId in dto.SpecialParts.Select(p => p.DesignId).ToList())
                {
                    var part = _context.SpecialParts.FirstOrDefault(p => p.DesignId == designId);

                    if (part == null)
                    {
                        _logger.LogError($"Part with design ID '{designId}' does not exsist");
                        continue;
                    }

                    postPartsToAdd.Add(new PostPart { PostId = post.Id, PartId = part.DesignId });
                }

                var postPartsToDelete = _context.PostParts.Where(pp => pp.PostId == post.Id).ToList();
                _context.PostParts.RemoveRange(postPartsToDelete);
                _context.PostParts.AddRange(postPartsToAdd);
            }
        }
    }
}
