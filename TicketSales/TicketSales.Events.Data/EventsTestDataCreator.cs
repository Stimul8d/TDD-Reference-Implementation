using Simple.Data;
using TicketSales.Events.Domain;
using TicketSales.Infrastructure.Data;

namespace TicketSales.Events.Data
{
    public class EventsTestDataCreator : ICreateTestData
    {
        private readonly Event PartyInThePark = 
            new Event(1, "Party in the Park", "Dorset");

        private readonly Event Download = 
            new Event(2, "Download Festival", "Staffordshire");

        public void Create()
        {
            var db = Database.Open();
            db.Events.DeleteAll();
            db.Events.Insert(PartyInThePark);
            db.Events.Insert(Download);
        }
    }
}
