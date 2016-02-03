using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketSales.Purchasing.Queries;
using TicketSales.Web.ViewModels.BuyTickets;

namespace TicketSales.Web.Controllers
{
    public class BuyTicketsController : Controller
    {
        private readonly AvailableTicketsQuery availableTicketsQuery;

        public BuyTicketsController(AvailableTicketsQuery availableTicketsQuery)
        {
            this.availableTicketsQuery = availableTicketsQuery;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buy(BuyTicketsRequestViewModel request)
        {
            return null;
        }
    }
}