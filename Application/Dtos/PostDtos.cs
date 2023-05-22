using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Application.Dtos
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        [JsonPropertyOrder(4)]
        public PartDto[] SpecialParts { get; set; }
    }

    public class EditPostDto : CreatePostDto
    {
        [JsonPropertyOrder(0)]
        public Guid Id { get; set; }
    }

    public sealed class PostDto : EditPostDto
    {
        [JsonPropertyOrder(5)]
        public ScoreDto[] Scores { get; set; }
    }
}
