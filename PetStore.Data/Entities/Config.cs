using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Entities
{
    public class Config
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Key { get; set; } = string.Empty;

        [Required]
        public string Value { get; set; } = string.Empty;
    }
}
