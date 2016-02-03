using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSales.Events.Domain
{
    public class Event
    {
        private readonly string location;
        private readonly string name;

        public string Name
        {
            get { return name; }
        }

        public string Location
        {
            get { return location; }
        }

        public Event(string name, string location)
        {
            this.name = name;
            this.location = location;
        }
    }
}
