using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportWearManage.Models;

namespace SportWearManage.Controllers
{
    public class ProductController : Controller
    {
        SportWearContext context = new SportWearContext();
        public IActionResult List(int id)
        {
/*            Account acc = TempData["acc"] as Account;
            ViewBag.Acc = acc;*/
            List<Account> accounts = context.Accounts.ToList();
            List<Category> categories = context.Categories.ToList();
            List<Product> products = new List<Product>();
            if (id != 0) { 
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
        public IActionResult Add()
        {
            using (SportWearContext context = new SportWearContext())
            {
                var data1 = context.Categories.ToList();
                var data2 = context.Accounts.ToList();
                ViewBag.Categories = data1;
                ViewBag.Accounts = data2;
                return View();
            }
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            using (SportWearContext context = new SportWearContext())
            {
                if (ModelState.IsValid)
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                    return RedirectToAction("List");
                }
                return View();
            }
        }
        public IActionResult Update(int id)
        {
            using (SportWearContext context = new SportWearContext())
            {
                var data1 = context.Categories.ToList();
                ViewBag.Categories = data1;
                var product = context.Products.Find(id);
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            using (SportWearContext context = new SportWearContext())
            {
                if (ModelState.IsValid)
                {
                    context.Products.Update(product);
                    context.SaveChanges();
                    return RedirectToAction("List");
                }
                else
                {
                    var data1 = context.Categories.ToList();
                    ViewBag.Categories = data1;
                    return View(product);
                }
            }
        }
        //Delete product
        public IActionResult Delete(int id)
        {
            using (SportWearContext context = new SportWearContext())
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                return RedirectToAction("List");
            }
        }
        public IActionResult Detail(int id)
        {
            using (SportWearContext context = new SportWearContext())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == id);
                return View(product);
            }
        }
    }
}
