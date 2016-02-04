using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketSales.Web.ViewModels.BuyTickets
{
    public class ConfirmationViewModel : IHaveAMessage
    {
        public string Message { get; set; }
    }
}