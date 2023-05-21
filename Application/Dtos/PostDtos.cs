using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        
        [Column(Order = 4)]
        public PartDto[] SpecialParts { get; set; }
    }

    public class EditPostDto : CreatePostDto
    {
        [Column(Order = 0)]
        public Guid Id { get; set; }
    }

    public sealed class PostDto : EditPostDto
    {
        [Column(Order = 5)]
        public ScoreDto[] Scores { get; set; }
    }
}
