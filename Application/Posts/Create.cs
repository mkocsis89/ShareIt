using Application.Core;
using Application.Dtos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Posts
{
    public sealed class Create
    {
        public sealed class Command : IRequest<Result<Unit>>
        {
            public CreatePostDto Post { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<Handler> _logger;

            public Handler(DataContext context, IMapper mapper, ILogger<Handler> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var post = _mapper.Map<Post>(request.Post);
                _context.Posts.Add(post);
                var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (!isSuccess)
                    return Result<Unit>.Failure("Failed to create post");

                var partsToAdd = new List<PostPart>();

                foreach (var designId in request.Post.SpecialParts.Select(p => p.DesignId).ToList())
                {
                    var part = _context.SpecialParts.FirstOrDefault(p => p.DesignId == designId);

                    if (part == null)
                    {
                        _logger.LogError($"Part with design ID '{designId}' does not exsist");
                        continue;
                    }

                    partsToAdd.Add(new PostPart { PostId = post.Id, PartId = part.DesignId });
                }

                _context.PostParts.AddRange(partsToAdd);
                isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;

                return isSuccess
                    ? Result<Unit>.Success(Unit.Value)
                    : Result<Unit>.Failure("Failed to create post");
            }
        }
    }
}
