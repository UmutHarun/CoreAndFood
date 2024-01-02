using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAndFood.Models
{
	public class Category
	{
		[Key]
        public int CategoryId { get; set; }

		[Required(ErrorMessage = "Category Name cannot be empty!")]
		[StringLength(20, ErrorMessage = "Please enter between 3 and 20 characters!",MinimumLength =3)]
		public string CategoryName { get; set; }

		//
		public List<Food> Foods { get; set; }

        
    }
}
