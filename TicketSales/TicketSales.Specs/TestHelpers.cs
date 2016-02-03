using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TicketSales.Specs
{
    public static class TestHelpers
    {
        public static T Model<T>(this ActionResult ar) where T : class
        {
            return (T)((ViewResult)ar).Model;
        }
    }
}
