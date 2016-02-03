using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Omu.ValueInjecter;
using TicketSales.Events.Domain;

namespace TicketSales.Web.ViewModels.Search
{
    public class SearchResponseViewModel
    {
        private readonly IEnumerable<SearchedEventViewModel> events;

        public IEnumerable<SearchedEventViewModel> Events
        {
            get { return events; }
        }

        public SearchResponseViewModel(IEnumerable<Event> events)
        {
            this.events = events.Select(e => Mapper.Map<Event, SearchedEventViewModel>(e));
        }

        public SearchResponseViewModel(IEnumerable<SearchedEventViewModel> events)
        {
            this.events = events;
        }
    }
}