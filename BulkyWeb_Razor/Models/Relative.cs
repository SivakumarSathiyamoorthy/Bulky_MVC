using Microsoft.EntityFrameworkCore;
using BulkyWeb_Razor.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyWeb_Razor.Models
{
    public class Relative
    {
        [Key]
        public int RelativeId { get; set; }
        [Required]
        [MaxLength(20)]
        public string? RelativeName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Relationship { get; set; } = string.Empty;

    }
  
}
