namespace Domain.Dtos
{
    public class PostDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public PartDto[] SpecialParts { get; set; }
    }
}
