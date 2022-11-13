using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SportWearManage.Models;
using SportWearManage.ViewModels;

namespace SportWearManage.Controllers
{
    public class ListBuyController : Controller
    {
        SportWearContext context = new SportWearContext();
        public IActionResult ListBuy(int id, string search)
        {
            //get data từ session
            var accJson = HttpContext.Session.GetString("user");
            //parse data sang kiểu ban đầu (Account)
            var acc = JsonConvert.DeserializeObject<Account>(accJson);

            /*            Account acc = TempData["acc"] as Account;
                        ViewBag.Acc = acc;*/
            List<Account> accounts = context.Accounts.ToList();
            List<Category> categories = context.Categories.ToList();
            List<Product> products = new List<Product>();

            //khi người dùng k search thì search sẽ mặc định là chuỗi rỗng
            //hoặc người dùng chỉ nhập toàn khoảng trắng
            if (search == null || "".Equals(search.Trim()))
                search = "";

            if (id != 0)
            {
                products = context.Products.Include(x => x.Category)
                    .Where(x => x.CategoryId == id && x.ProductName.ToLower()
                    .Contains(search.ToLower()))
                    .ToList();
            }
            else
            {
                products = context.Products.Where(x => x.ProductName.ToLower()
                .Contains(search.ToLower()))
                .ToList();
            }
            ViewBag.Username = acc.Username;
            ViewData["Accounts"] = accounts;
            ViewData["Categories"] = categories;
            ViewData["id"] = id;
            return View(products);
        }
        public IActionResult Detail(int id)
        {
            using (SportWearContext context = new SportWearContext())
            {
                //get data từ session
                var accJson = HttpContext.Session.GetString("user");
                //parse data sang kiểu ban đầu (Account)
                var acc = JsonConvert.DeserializeObject<Account>(accJson);
                var product = context.Products.FirstOrDefault(p => p.ProductId == id);
                ViewBag.Username = acc.Username;
                return View(product);
            }
        }
    }
}
