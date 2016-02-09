using Simple.Data;
using StructureMap;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Web.DependencyResolution;

namespace TicketSales.Specs
{
    public class IntegrationTestBase
    {
        private readonly IContainer container;
        public IContainer Container
        {
            get { return container; }
        }

        protected dynamic Db;

        public IntegrationTestBase()
        {
            container = IoC.Initialize();
            DomainEvents.Container = container;

            Database.UseMockAdapter(new InMemoryAdapter());
            Db = Database.Open();
        }
    }
}