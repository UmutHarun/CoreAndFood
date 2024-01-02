using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class GetCategoryList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository repository = new CategoryRepository();
            var catList = repository.TList();
            return View(catList);
        }
    }
}
