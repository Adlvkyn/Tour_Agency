using System.ComponentModel.DataAnnotations;

namespace TourFirm.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Firstname { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Lastname { get; set; }

        [RegularExpression(@"^-?[0-9][0-9,\.]+$")]
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string? Phonenumber { get; set; }

        [Range(18, 70)]
        public int Age { get; set; }
    }
}
