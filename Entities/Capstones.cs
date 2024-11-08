using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CapstoneGenerator.Server.Models
{
    public class Capstones
    {
        [Key]
        public int CapstoneId {  get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        [Required]
        public string Categories { get; set; } = "";

        [Required]
        public string CreatedBy { get; set; } = "";

        public float Rating { get; set; }
    }
}
