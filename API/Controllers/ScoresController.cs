using Application.Dtos;
using Application.Scores;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public sealed class ScoresController : BaseApiController
    {
        [HttpPost("/{postId}/scores")]
        public async Task<IActionResult> Score(Guid postId, CreateScoreDto score)
        {
            return HandleResult(await Mediator.Send(new Create.Command { PostId = postId, Score = score }));
        }

        [HttpDelete("/{postId}/scores/{scoreId}")]
        public async Task<IActionResult> RemoveScore(Guid postId, Guid scoreId)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { PostId = postId, ScoreId = scoreId }));
        }
    }
}
