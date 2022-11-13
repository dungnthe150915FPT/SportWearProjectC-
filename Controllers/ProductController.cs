using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SportWearManage.Models;
using SportWearManage.ViewModels;

namespace SportWearManage.Controllers
{
    public class ProductController : Controller
    {
        SportWearContext context = new SportWearContext();
        public IActionResult List(int id, string search = null)
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
            ViewData["Accounts"] = accounts;
            ViewData["Categories"] = categories;
            ViewData["id"] = id;
            return View(products);
        }
        public IActionResult Add()
        {
            using (SportWearContext context = new SportWearContext())
            {
                //get data từ session
                var accJson = HttpContext.Session.GetString("user");
                //parse data sang kiểu ban đầu (Account)
                var acc = JsonConvert.DeserializeObject<Account>(accJson);

                var data1 = context.Categories.ToList();
                var data2 = context.Accounts.ToList();
                ViewBag.Categories = data1;
                ViewBag.Accounts = data2;
                ViewBag.AccountId = acc.AccountId;
                return View();
            }
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            using (SportWearContext context = new SportWearContext())
            {
                if (ModelState.IsValid)
                {
                    var addProduct = ProductViewModel.ToProduct(product);
                    context.Products.Add(addProduct);
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
        public IActionResult Update(ProductViewModel product)
        {
            using (SportWearContext context = new SportWearContext())
            {
                if (ModelState.IsValid)
                {
                    //convert từ model view sang model của database
                    var updateProduct = ProductViewModel.ToProduct(product);
                    context.Products.Update(updateProduct);
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
