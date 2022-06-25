using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class MyAppController : Controller
    {
        public IActionResult Index()
        {
            var model = new MyAppModel();
            model.Name = "Jacek";
            model.LastName = "Filipski";

            return View(model);
        }
    }
}
