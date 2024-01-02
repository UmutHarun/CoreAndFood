using CoreAndFood.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
	public class FoodController : Controller
	{
        Context c = new Context();
        FoodRepository repository = new FoodRepository();
        public IActionResult Index(int? page)
		{
            var pageNum = page ?? 1;
            int pageSize = 3;
            var foodList = repository.TList("Category").ToPagedList(pageNum, pageSize);

            return View(foodList);
		}

        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = c.Categories.ToList().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString(),
            }).ToList();
            ViewBag.values = values;

            return View();
        }
           
 
        [HttpPost]
        public IActionResult AddFood(Food f)
        {
            var cat = c.Categories.Where(x => x.CategoryId == f.Category.CategoryId).FirstOrDefault();
            f.Category = cat;
            c.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFood(int id)
        {
            repository.DeleteT(new Food { FoodId = id });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditFood(int id)
        {
            List<SelectListItem> values = c.Categories.ToList().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString(),
            }).ToList();
            ViewBag.values = values;

            var food = repository.GetT(id);
            ViewBag.categ = food.CategoryId.ToString();

            return View(food);
        }

        [HttpPost]
        public IActionResult EditFood(Food f)
        {
            var cat = c.Categories.Where(x => x.CategoryId == f.Category.CategoryId).FirstOrDefault();
            f.Category = cat;
            //Food food = new Food 
            //{ 
            //    FoodId = f.FoodId, 
            //    Name = f.Name,
            //    Price = f.Price,
            //    Stock = f.Stock,
            //    Category = cat,
            //    Description = f.Description,
            //    ImgUrl=f.ImgUrl,               
            //};
            c.Update(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
