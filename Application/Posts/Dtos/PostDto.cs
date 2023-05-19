namespace Application.Posts.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public PartDto[] SpecialParts { get; set; }
    }
}
