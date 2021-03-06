﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketSales.Events.Domain;
using TicketSales.Infrastructure;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain;
using TicketSales.Purchasing.Domain.Events;
using TicketSales.Purchasing.Queries;
using TicketSales.Web.ViewModels.BuyTickets;

namespace TicketSales.Web.Controllers
{
    public class BuyTicketsController : Controller
    {
        private readonly IBoxOffice boxOffice;
        private readonly IQuery<int, Order> ordersQuery;
        private readonly IQuery<int, Event> eventsQuery;
        private readonly IQuery<int, Ticket> ticketsQuery;

        public BuyTicketsController(IBoxOffice boxOffice,
            IQuery<int, Order> ordersQuery, IQuery<int, Event> eventsQuery,
            IQuery<int,Ticket> ticketsQuery)
        {
            this.boxOffice = boxOffice;
            this.ordersQuery = ordersQuery;
            this.eventsQuery = eventsQuery;
            this.ticketsQuery = ticketsQuery;
        }

        public ActionResult Index(int id)
        {
            var @event = eventsQuery.Execute(id).FirstOrDefault();
            if (@event == null) RedirectToAction("Search", "Events");
            var numOfTickets = ticketsQuery.Execute(id).Count();

            var vm = new BuyTicketsSummaryViewModel(numOfTickets, @event.Id, @event.Name, @event.Location);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Buy(BuyTicketsRequestViewModel request)
        {
            try
            {
                var ordersBefore = ordersQuery.Execute(request.UserId).Count();

                boxOffice.SellTickets(request.UserId,
                    request.EventId, request.NumberOfTicketsRequired);

                var ordersAfter = ordersQuery.Execute(request.UserId).Count();
                var sucessfulOrder = ordersAfter == ordersBefore + 1;

                return RedirectToAction(sucessfulOrder ? "Confirmation" : "Cantformation");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
                throw;
            }

        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Confirmation()
        {
            return View(new ConfirmationViewModel { Message = "Thanks!!" });
        }

        public ActionResult Cantformation()
        {
            return null;
        }
    }
}