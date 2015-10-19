using System.Web.Mvc;

namespace Demo.XBanking.Models
{
    public class LineItem
    {
        public int Amount { get; set; }

        [AllowHtml]
        public string Message { get; set; }
    }
}