using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public sealed class Part
    {
        [Key]
        public uint SerialNumber { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
