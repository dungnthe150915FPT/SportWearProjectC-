using Microsoft.AspNetCore.Mvc;
using SportWearManage.Models;

namespace SportWearManage.Controllers
{
    public class LoginController : Controller
    {
        SportWearContext context = new SportWearContext();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            Account? acc = context.Accounts.Where(a => a.Username == Username && a.Password == Password).FirstOrDefault();
            if(acc == null)
            {
                return View();
            }
            else
            {
                /*TempData["acc"] = acc;*/
                //return RedirectToAction("List", "Product");
                //return View(acc);
                if(acc.IsAdmin == 1)
                {
                    return Redirect("Product/List");
                }
                else
                {
                    return Redirect("ListBuy/ListBuy");
                }
            }
        }
    }
}
