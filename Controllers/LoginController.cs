using Microsoft.AspNetCore.Mvc;
using SportWearManage.Models;

namespace SportWearManage.Controllers
{
    public class LoginController : Controller
    {
        SportWearContext context = new SportWearContext();
        public IActionResult Login()
        {
            //List<>
            return View();
        }
    }
}
