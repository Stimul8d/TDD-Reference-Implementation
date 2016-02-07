using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Simple.Data;
using TicketSales.Purchasing.Data;
using TicketSales.Purchasing.Domain;
using Xunit;

namespace TicketSales.Tests.Purchasing
{
    public class TicketRepositoryTests
    {
        [Theory, TestData]
        public void All_Returns_Correct_Result(
            TicketRepository sut, IEnumerable<Ticket> data)
        {
            Database.Open().Tickets.Insert(data);

            var result = sut.All();
            result.ShouldAllBeEquivalentTo(data);
        }

        [Theory, TestData]
        public void Delete_Removes_Correct_Data(
            TicketRepository sut, IEnumerable<Ticket> data)
        {
            var db = Database.Open();
            db.Tickets.Insert(data);
            var countBefore = data.Count();

            sut.Delete(data.First());
            var countAfter = (int)db.Tickets.GetCount();
            countAfter.Should().Be(countBefore - 1);
        }
    }
}
