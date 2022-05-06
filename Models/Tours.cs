using System.ComponentModel.DataAnnotations;

namespace TourFirm.Models
{
    public class Tours
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Range(3000, 50000)]
        public int Price { get; set; }

        [Display(Name = "Tour Date")]
        [DataType(DataType.Date)]
        public DateTime TourDate { get; set; }

        
    }
}
