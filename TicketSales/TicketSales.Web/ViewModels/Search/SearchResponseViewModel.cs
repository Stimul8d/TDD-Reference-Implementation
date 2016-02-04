using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Omu.ValueInjecter;
using TicketSales.Events.Domain;

namespace TicketSales.Web.ViewModels.Search
{
    public class SearchResponseViewModel : IHaveAMessage
    {
        private readonly IEnumerable<SearchedEventViewModel> events;
        private readonly string message;

        public IEnumerable<SearchedEventViewModel> Events
        {
            get { return events; }
        }

        public string Message
        {
            get { return message; }
        }

        public SearchResponseViewModel(IEnumerable<Event> events, string message = "Search Results") :
            this(events.Select(e => Mapper.Map<Event, SearchedEventViewModel>(e)), message)
        { }

        public SearchResponseViewModel(IEnumerable<SearchedEventViewModel> events, string message)
        {
            this.events = events;
            this.message = message;
        }
    }
}