using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketSales.Web.ViewModels.BuyTickets
{
    public class BuyTicketsRequestViewModel
    {
        public int EventId { get; set; }
        public int NumberOfTicketsRequired { get; set; }
    }
}