using Menu.Data;
using Menu.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    public class Menu : Controller
    {
        private readonly MenuContext _context;

        public Menu(MenuContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           List<Dish> dishes = _context.Dishes.ToList();
            return View(dishes);
        }
    }
}
