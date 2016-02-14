using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketSales.Web.ViewModels.BuyTickets
{
    public class BuyTicketsSummaryViewModel
    {
        public int Id { get; }
        public string Location { get; }
        public string Name { get; }
        public int NumOfTickets { get; }

        public BuyTicketsSummaryViewModel(int numOfTickets, int id, string name, string location)
        {
            this.NumOfTickets = numOfTickets;
            this.Id = id;
            this.Name = name;
            this.Location = location;
        }
    }
}