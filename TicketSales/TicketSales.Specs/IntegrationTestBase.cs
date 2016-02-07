using System.Collections.Generic;
using NSubstitute;
using Simple.Data;
using StructureMap;
using TicketSales.Events.Domain;
using TicketSales.Infrastructure.Data;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain;
using TicketSales.Web.DependencyResolution;

namespace TicketSales.Specs
{
    public class IntegrationTestBase
    {
        private IContainer container;
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