using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.ValueInjecter;
using TicketSales.Events.Domain;
using TicketSales.Web.ViewModels.Search;
using TicketSales.Infrastructure;

namespace TicketSales.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IQuery<string, Event> eventQuery;

        public EventsController(IQuery<string, Event> eventQuery)
        {
            this.eventQuery = eventQuery;
        }

        // GET: Events
        public ActionResult Search(SearchRequestViewModel searchViewModel)
        {
            IEnumerable<Event> events = new List<Event>();
            var message = "Search Results...";
            try
            {
                events = eventQuery.Execute(searchViewModel.Term).ToList();
                if (!events.Any()) message = "No Results";
            }
            catch (Exception)
            {
                message = "Oops. Something went wrong!";
            }
            return View(new SearchResponseViewModel(events, message));
        }
    }
}