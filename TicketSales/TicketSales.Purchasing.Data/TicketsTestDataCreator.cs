using System;
using Simple.Data;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Purchasing.Data
{
    public class TicketsTestDataCreator : ICreateTestData
    {
        private readonly Ticket PartyInTheParkTicket = new Ticket(
            Guid.NewGuid(), 1);

        private readonly Ticket DownloadTicket = new Ticket(
            Guid.NewGuid(), 2);

        public void Create()
        {
            var db = Database.Open();
            db.Tickets.Insert(PartyInTheParkTicket);
            db.Tickets.Insert(DownloadTicket);
        }
    }
}
