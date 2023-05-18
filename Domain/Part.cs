using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public sealed class Part
    {
        [Key]
        public string Name { get; set; }
        public Guid PostId { get; set; }
    }
}
