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
            var events = eventQuery.Execute(searchViewModel.Term);
            var message = "Search Results...";
            if (!events.Any()) message = "No Results";
            return View(new SearchResponseViewModel(events, message));
        }
    }
}