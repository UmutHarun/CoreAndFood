using CoreAndFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Controllers
{

    public class ChartController : Controller
    {
        double totalPriceOfFood;
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<ChartF> ProList()
        {
            List<ChartF> charts = new List<ChartF>();
            //charts = c.Foods.Select(f =>
            //    new ChartF
            //    {
            //        stock = f.Stock,
            //        foodname = f.Name
            //    }
            //).ToList();
            // YUKARIDAKİ DE ALTTAKİ DE ÇALIŞIYOR 
            // ALTTAKİNDE TOLİST KULLANMADIĞIMIZ ZAMAN FOREACHASYNC ÇIKIYOR
            // AMA ÇALIŞMIYOR BU YÜZDEN TOLİST KULLANIP FOREACH KULLANDIK
            // BAK SEN ŞU İŞE
            c.Foods.ToList().ForEach(c =>
            {
                charts.Add(new ChartF
                {
                    foodname = c.Name,
                    stock = c.Stock
                });
            });

            return charts;
        }

        public IActionResult Statistics()
        {
            int totalCategory = c.Categories.Count();
            ViewBag.totalCategory = totalCategory;

            int totalFood = c.Foods.Count();
            ViewBag.totalFood = totalFood;

            int totalFruit = c.Foods.Where(c => c.Category.CategoryName == "Fruit").Count();
            ViewBag.totalFruit = totalFruit;

            int totalVegetables = c.Foods.Where(c => c.Category.CategoryName == "Vegetable").Count();
            ViewBag.totalVegetables = totalVegetables;

            int sumOfFood = c.Foods.Sum(c => c.Stock);
            ViewBag.sumOfFood = sumOfFood;

            c.Foods.ToList().ForEach((c) =>
            {
                totalPriceOfFood += c.Price * c.Stock;
            });
            ViewBag.totalPriceOfFood = totalPriceOfFood;

            double averagePrice = totalPriceOfFood / sumOfFood;
            ViewBag.averagePrice = averagePrice;


			return View();
        }
    }
}
