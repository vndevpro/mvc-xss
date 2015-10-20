using Demo.XBanking.Models;
using System.Web.Mvc;

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
