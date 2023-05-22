namespace Application.Dtos
{
    public sealed class PostDto
    {
        /// <remarks>
        /// Represents <c>null</c> for create operation.
        /// </remarks>
        public Guid? Id { get; set; }
        
        public string Title { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Description { get; set; }
        
        public PartDto[] SpecialParts { get; set; }

        /// <remarks>
        /// Represents <c>null</c> for create and update operations.
        /// </remarks>
        public ScoreDto[] Scores { get; set; }
    }
}
