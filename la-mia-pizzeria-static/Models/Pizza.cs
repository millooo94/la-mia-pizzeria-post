using la_mia_pizzeria_static.Attributes;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "Please provide a name.")]
		public string Name { get; set; } = string.Empty;
		[Required(ErrorMessage = "Please provide a description.")]
		[AtLeastFiveWords]
		public string Description { get; set; } = string.Empty;
		[Required(ErrorMessage = "Please provide a price.")]
		[Range(1, int.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore di 0")]
		public float Price { get; set; }
		[Required(ErrorMessage = "Please provide an image.")]

		public string Img { get; set; } = string.Empty;

    }
}
