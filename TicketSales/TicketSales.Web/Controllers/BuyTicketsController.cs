using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain.Events;
using TicketSales.Purchasing.Queries;
using TicketSales.Web.ViewModels.BuyTickets;

namespace TicketSales.Web.Controllers
{
    public class BuyTicketsController : Controller
    {
        private readonly OrdersQuery ordersQuery;

        public BuyTicketsController(OrdersQuery ordersQuery)
        {
            this.ordersQuery = ordersQuery;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buy(BuyTicketsRequestViewModel request)
        {
            var ordersBefore = ordersQuery.Execute(request.UserId).Count();

            DomainEvents.Raise(
                new TicketsPurchasedEvent(request.UserId,
                    request.EventId, request.NumberOfTicketsRequired));

            var ordersAfter = ordersQuery.Execute(request.UserId).Count();
            var sucessfulOrder = ordersAfter == ordersBefore + 1;
            return RedirectToAction(sucessfulOrder ? "Confirmation" : "Cantformation");
        }

        public ActionResult Confirmation()
        {
            return View(new ConfirmationViewModel {Message="Thanks!!"});
        }

        public ActionResult Cantformation()
        {
            return null;
        }
    }
}