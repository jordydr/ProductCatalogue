using System.ComponentModel.DataAnnotations;

namespace ProductCatalogue.Models
{
    public class Product
    {
        [Required]
        //[Range(0, 9999999999999, ErrorMessage = "The value of {0} must range between {1} and {2}")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The property {0} doesn't have more than {1} elements")]
        public string? Name { get; set; }

        [Required]
        public int PotSize { get; set; }

        [Required]
        public int PlantHeight { get; set; }

        public string? Colour { get; set; }

        [Required]
        public string? ProductGroup { get; set; }
    }
}
