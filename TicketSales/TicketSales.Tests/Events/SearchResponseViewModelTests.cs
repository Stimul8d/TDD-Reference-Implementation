using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using TicketSales.Events.Domain;
using TicketSales.Web.ViewModels.Search;
using Xunit;

namespace TicketSales.Tests.Events
{
    public class SearchResponseViewModelTests
    {
        [Theory, AutoData]
        public void Constructs_Properly_From_Event_List(IEnumerable<Event> events)
        {
            var sut = new SearchResponseViewModel(events);

            Func<SearchedEventViewModel, Event, bool> isEqual = (vm, ev) =>
                vm.Name == ev.Name && vm.Location == ev.Location;

            sut.Events.All(vm => events.Any(e => isEqual(vm, e)))
                .Should().BeTrue();
        }
    }
}
