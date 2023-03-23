using MusalaSoftDrones.Api.DomainEntities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusalaSoftDrones.Api.DomainEntities
{
    public class Drone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string SerialNumber { get; set; }

        [Range(0, 500,
              ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Weight { get; set; }

        [Range(0, 100,
                      ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Capacity { get; set; }

        public State State { get; set; }

        public Model Model { get; set; }
    }
}
