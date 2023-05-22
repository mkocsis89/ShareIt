using Domain;

namespace Application.Dtos
{
    public class ScoreDto
    {
        /// <remarks>
        /// Represents <c>null</c> for create operation.
        /// </remarks>
        public Guid Id { get; set; }

        // TODO UserId

        public ScoreType Type { get; set; }
    }
}
