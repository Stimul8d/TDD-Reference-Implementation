using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Simple.Data;
using TicketSales.Events.Data;
using TicketSales.Events.Domain;
using TicketSales.Tests.Purchasing;
using Xunit;

namespace TicketSales.Tests.Events
{
    public class EventRepositoryTests
    {
        [Theory, TestData]
        public void All_Returns_Correct_Result(
            EventRepository sut, IEnumerable<Event> data )
        {
            Database.Open().Events.Insert(data);

            var result = sut.All();
            result.ShouldAllBeEquivalentTo(data);
        }
    }
}
