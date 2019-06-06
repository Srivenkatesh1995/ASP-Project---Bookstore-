using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ANVBookstore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ANVBookstore.Controllers
{
    public class MainController : Controller
    {
        private readonly Team117DBContext aTeamDBContext;

        public MainController(Team117DBContext context) {

            aTeamDBContext = context;

        }

        public IActionResult TextbookView()
        {

            var textbooks = aTeamDBContext.Textbook.Include(t => t.Course).Include(t => t.OrderItems);
         
            return View(textbooks.ToList());

        }
        public IActionResult CourseView()
        {
            var textbooks = aTeamDBContext.Textbook.OrderBy(t => t.Course);
            return View(textbooks.ToList());


        }

        public IActionResult SearchView(string searchTerm, decimal? priceMin , decimal? priceMax, string radio)
        {
            var textbook = from a in aTeamDBContext.Textbook select a;
            textbook = textbook.Include(a => a.Course);
         
            if (!String.IsNullOrEmpty(searchTerm))
            {

                if (!String.IsNullOrEmpty(radio))
                {
                    if (radio.Equals("bookname"))
                    {
                        textbook = textbook.Where(b => b.Name.Contains(searchTerm));
                        TempData["SearchCriteria"] += " with title like " + searchTerm;
                    }
                    else if (radio.Equals("author"))
                    {
                        textbook = textbook.Where(b => b.Author.Contains(searchTerm));
                        TempData["SearchCriteria"] += " with author name like " + searchTerm;
                    }
                    
                }
            }

            if (priceMin != null)
            {
                textbook = textbook.Where(b => b.Price >= priceMin);
                TempData["PriceRange"] += "Minimum Price " + priceMin;
            }

            if (priceMax != null)
            {
                textbook = textbook.Where(b => b.Price <= priceMax);
                TempData["PriceRange"] += " Maximum Price " + priceMax;
            }
            
            return View(textbook.OrderBy(b => b.Name).ToList());
        }

        public IActionResult SortView(string sortOrder)
        {
            ViewData["NameSortProgram"] = String.IsNullOrEmpty(sortOrder) ? "Name" : " ";
            ViewData["PriceSortParam"] = sortOrder == "price" ? "priceDesc" : "price";
            var textbooks = from t in aTeamDBContext.Textbook select t;
            switch (sortOrder)
            {
                case "nameDesc":
                    textbooks = textbooks.OrderByDescending(t => t.Name);
                    break;
                case "price":
                    textbooks = textbooks.OrderBy(t => t.Price);
                    break;
                case "priceDesc":
                    textbooks = textbooks.OrderByDescending(t => t.Price);
                    break;
                default:
                    textbooks = textbooks.OrderBy(t => t.Name);
                    break;
            }
            return View(textbooks.ToList());

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}