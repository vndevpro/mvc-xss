using Rabbit.SimpleInjectorDemo.Services;
using System.Web.Mvc;

namespace Demo.XBanking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IListingService _listingService;

        public HomeController(IListingService listingService)
        {
            _listingService = listingService;
        }

        public ActionResult Index()
        {
            ViewBag.ListingCount = _listingService.Count();

            return View();
        }


    }
}
