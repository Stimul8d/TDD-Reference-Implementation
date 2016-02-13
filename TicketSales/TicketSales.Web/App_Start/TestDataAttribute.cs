using System.Diagnostics;
using System.Web.Mvc;
using Simple.Data;

namespace TicketSales.Web
{
    public class TestDataAttribute : ActionFilterAttribute
    {
        private static InMemoryAdapter adapter;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UseInMemory();
        }

        [Conditional("DEBUG")]
        void UseInMemory()
        {
            if(adapter == null) adapter = new InMemoryAdapter();

            Database.UseMockAdapter(adapter);
        }
    }
}