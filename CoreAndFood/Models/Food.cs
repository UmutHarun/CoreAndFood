using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Models
{
	public class Food
	{
		[Key]
		public int FoodId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string ImgUrl { get; set; }
		public int Stock { get; set; }
	//

		public virtual int CategoryId { get; set; }
		public Category Category { get; set; }

    }
}
