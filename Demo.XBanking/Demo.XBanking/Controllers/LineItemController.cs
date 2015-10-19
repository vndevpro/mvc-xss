using System.Web.Mvc;
using Demo.XBanking.Models;
using Microsoft.Security.Application;

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
            var safeHtml = Sanitizer.GetSafeHtmlFragment(item.Message);

            return View(item);
        }
    }
}
