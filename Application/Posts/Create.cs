using Application.Core;
using Application.Posts.Dtos;
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
            public PostDto Post { get; set; }
        }

        public sealed class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly ILogger<Handler> _logger;

            public Handler(DataContext context, ILogger<Create.Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var post = Map(request.Post);
                _context.Posts.Add(post);

                var isSuccess = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (isSuccess)
                    return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Failed to create post");
            }

            // TODO custom automapper
            private Post Map(PostDto dto)
            {
                var post = new Post
                {
                    Title = dto.Title,
                    Date = dto.Date,
                    Description = dto.Description
                };

                var parts = new List<Part>();

                foreach (var serialNumber in dto.SpecialParts.Select(p => p.SerialNumber).ToList())
                { 
                    var part = _context.SpecialParts.FirstOrDefault(p => p.SerialNumber == serialNumber);

                    if (part == null)
                    {
                        _logger.LogError($"Part with serial number '{serialNumber}' does not exsist");
                        continue;
                    }

                    parts.Add(part);
                }

                post.SpecialParts = parts;
                return post;
            }
        }
    }
}
