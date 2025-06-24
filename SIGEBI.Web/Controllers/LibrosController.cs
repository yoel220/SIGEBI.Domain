
using Microsoft.AspNetCore.Mvc;

namespace SIGEBI.Web.Controllers
{
    public class LibrosController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Create() => View();
        public IActionResult Edit() => View();
        public IActionResult Delete() => View();
    }
}
