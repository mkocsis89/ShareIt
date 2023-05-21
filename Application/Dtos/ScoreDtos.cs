using Domain;

namespace Application.Dtos
{
    public class CreateScoreDto
    {
        // TODO UserId
        public ScoreType Type { get; set; }
    }

    public  sealed class ScoreDto : CreateScoreDto
    { 
        public Guid Id { get; set; }
    }
}
