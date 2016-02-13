using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketSales.Infrastructure.Data;

namespace TicketSales.Web.Controllers
{
    public class HomeController : Controller
    {
        private IEnumerable<ICreateTestData> testData;

        public HomeController(IEnumerable<ICreateTestData> testData)
        {
            this.testData = testData;
        }
        // GET: Home
        public ActionResult Index()
        {
            foreach (var creator in testData) creator.Create();
            return RedirectToAction("Search", "Events");
        }
    }
}