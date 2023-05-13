using Application.Commands;
using Application.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public sealed class PostsController : BaseApiController
    {
        // Enpoints..

        [HttpGet]   //api/posts/id
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            return await Mediator.Send(new GetAllPostsQuery());
        }

        [HttpGet("{id}")]   //api/posts/id
        public async Task<ActionResult<Post>> GetPost(Guid id)
        {
            return await Mediator.Send(new GetPostByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            await Mediator.Send(new CreatePostCommand { Post = post });
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPost(Guid id, Post post)
        {
            post.Id = id;
            await Mediator.Send(new EditPostCommand { Post = post });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            await Mediator.Send(new DeletePostCommand { Id = id });
            return Ok();
        }
    }
}
