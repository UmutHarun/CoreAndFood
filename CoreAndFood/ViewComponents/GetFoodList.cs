using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class GetFoodList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepository repository = new FoodRepository();
            var foodList = repository.TList();
            return View(foodList);
        }
    }
}
