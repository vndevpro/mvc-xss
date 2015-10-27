using Demo.XBanking.Data;
using Rabbit.SimpleInjectorDemo.Services;
using System.Linq;
using System.Web.Mvc;

namespace Demo.XBanking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IListingService _listingService;
        private readonly XBankingDbContext _dbContext;

        public HomeController(IListingService listingService)
        {
            _listingService = listingService;
            _dbContext = new XBankingDbContext();
        }

        public ActionResult Index()
        {
            ViewBag.ListingCount = _listingService.Count();
            ViewBag.ApplicationVersion = typeof(MvcApplication).Assembly.GetName().Version;

            var lastestVersion = _dbContext.Configurations.OrderByDescending(c => c.SetupDate).FirstOrDefault();
            if (lastestVersion != null)
            {
                ViewBag.LastestVersion = lastestVersion.Version;
                ViewBag.LastestVersionDate = lastestVersion.SetupDate;
            }

            return View();
        }
    }
}
