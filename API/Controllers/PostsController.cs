using Application.Commands;
using Application.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public sealed class PostsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts(CancellationToken cancellationToken)
        {
            return HandleResult(await Mediator.Send(new GetPostsQuery(), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetPostQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            return HandleResult(await Mediator.Send(new CreatePostCommand { Post = post }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPost(Guid id, Post post)
        {
            post.Id = id;
            return HandleResult(await Mediator.Send(new EditPostCommand { Post = post }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeletePostCommand { Id = id }));
        }
    }
}
