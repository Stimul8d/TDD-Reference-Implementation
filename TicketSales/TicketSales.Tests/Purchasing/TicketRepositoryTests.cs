using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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

        [Theory, TestData]
        public void GetNext_Get_Correct_Data(TicketRepository sut)
        {
            var db = Database.Open();
            db.Tickets.Insert(TestData.AllTickets);
            var results = sut.GetNext(TestData.TenLessThanTotalNumberOfTickets).ToList();
            
            results.ShouldAllBeEquivalentTo(TestData.AllTickets.Take(10));
        }
    }
}
