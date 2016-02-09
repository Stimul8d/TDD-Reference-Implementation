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
