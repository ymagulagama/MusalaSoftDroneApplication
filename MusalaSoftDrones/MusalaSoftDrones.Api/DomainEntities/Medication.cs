using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusalaSoftDrones.Api.DomainEntities
{
    public class Medication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        public string Code { get; set; }

        [RegularExpression(@"[A-Z0-9_]+",
        ErrorMessage = "Password must meet requirements")]
        public string Name { get; set; }

        public int Weight { get; set; }

        public byte[] Image { get; set; }

        [ForeignKey("SerialNumber")]
        public Drone Drones { get; set; }
    }
}
