using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSales.Events.Domain
{
    public class Event
    {
        private readonly int id;
        private readonly string location;
        private readonly string name;

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Location
        {
            get { return location; }
        }

        public Event(int id, string name, string location)
        {
            this.id = id;
            this.name = name;
            this.location = location;
        }
    }
}
