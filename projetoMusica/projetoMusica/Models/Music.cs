using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace projetoMusica.Models
{
    public class Music
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public String musicName { get; set; }
        [Required]
        [MaxLength(200)]
        public String Artist { get; set; }
        [Required]
        [MaxLength(200)]
        public String Genre { get; set; }
        [Required]
        public bool Explicit { get; set; }
        [Required]
        public String releaseDate { get; set; }
    }
}
