using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportWearManage.Models;

namespace SportWearManage.Controllers
{
    public class ListBuyController : Controller
    {
        SportWearContext context = new SportWearContext();
        public IActionResult ListBuy(int id)
        {
            List<Account> accounts = context.Accounts.ToList();
            List<Category> categories = context.Categories.ToList();
            List<Product> products = new List<Product>();
            if (id != 0)
            {
                products = context.Products.Include(x => x.Category).Where(x => x.CategoryId == id).ToList();
            }
            else
            {
                products = context.Products.ToList();
            }
            ViewData["Accounts"] = accounts;
            ViewData["Categories"] = categories;
            ViewData["id"] = id;
            return View(products);
        }
    }
}
