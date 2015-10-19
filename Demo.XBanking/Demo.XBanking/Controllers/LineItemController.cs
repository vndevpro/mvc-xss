using System.Web.Mvc;
using Demo.XBanking.Models;

namespace Demo.XBanking.Controllers
{
    public class LineItemController : Controller
    {
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(LineItem item)
        {
            return View(item);
        }
    }
}