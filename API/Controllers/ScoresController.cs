using Application.Dtos;
using Application.Scores;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/posts/{postId}/[controller]")]
    public sealed class ScoresController : BaseApiController
    {
        [HttpPost()]
        public async Task<IActionResult> Score(Guid postId, ScoreDto score)
        {
            return HandleResult(await Mediator.Send(new Create.Command { PostId = postId, Score = score }));
        }

        [HttpDelete("{scoreId}")]
        public async Task<IActionResult> RemoveScore(Guid postId, Guid scoreId)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { PostId = postId, ScoreId = scoreId }));
        }
    }
}
