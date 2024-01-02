using CoreAndFood.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
	public class CategoryController : Controller
	{
        CategoryRepository repository = new CategoryRepository();
        Context c = new Context();

        //[Authorize]
        public IActionResult Index()
		{
			return View(c.Categories.ToList());
		}

		[HttpGet]
		public IActionResult AddCategory()
		{ 
			return View();
		}

		[HttpPost]
        public IActionResult AddCategory(Category c)
        {
            if(!ModelState.IsValid)
			{
                return View();
                
            }
            repository.AddT(c);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var x = repository.GetT(id);
            return View(x);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category c)
        {
            var t = repository.GetT(c.CategoryId);
            //if (t == null)
            //{
            //    return RedirectToAction("Index");
            //}
            //Category category = new Category() 
            //{
            //    CategoryId = t.CategoryId,
            //    CategoryName = c.CategoryName,
            //    //Foods = c.Foods,
            //};
            t.CategoryName = c.CategoryName;
            repository.UpdateT(t);
            return RedirectToAction("Index");
            // halledildi
        }

        public IActionResult DeleteCategory(int id) 
        {
            var t = repository.GetT(id);
            repository.DeleteT(t);
            return RedirectToAction("Index");
        }
    }
}
