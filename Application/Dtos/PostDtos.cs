namespace Application.Dtos
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public PartDto[] SpecialParts { get; set; }
    }

    public class EditPostDto : CreatePostDto
    {
        public Guid Id { get; set; }
    }

    public class PostDto : EditPostDto
    {
        public ScoreDto[] Scores { get; set; }
    }
}
