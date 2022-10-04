using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace projetoMusica.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public String artistName { get; set; }
        [Required]
        [MaxLength(200)]
        public String mainInstrument { get; set; }
        [Required]
        [MaxLength(200)]
        public String mainGenre { get; set; }
        [Required]
        [MaxLength(200)]
        public String born { get; set; }       
        [MaxLength(200)]
        [AllowNull]       
        public String? group { get; set; }
    }
}
