using System.ComponentModel.DataAnnotations;

namespace ManageGameApi.Domain.Input
{
    public class GameInput
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

    }
}
