using System.ComponentModel.DataAnnotations;

namespace TourFirm.Models
{
    public class Agencies
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Name { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Address { get; set; }

        [RegularExpression(@"^-?[0-9][0-9,\.]+$")]
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string? Phonenumber { get; set; }

        [Range(0, 10)]
        public int Rating { get; set; }
    }
}
