using System.Collections.Generic;
using NSubstitute;
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

        public IRepository<Event> EventRepository { get; set; }

        public IRepository<Ticket> TicketRepository { get; set; }

        public IntegrationTestBase()
        {
            container = IoC.Initialize();
            //container.EjectAllInstancesOf<IRepository<Event>>();
            //container.EjectAllInstancesOf<IRepository<Ticket>>();

            //EventRepository = Substitute.For<IRepository<Event>>();
            //container.Inject(typeof(IRepository<Event>), EventRepository);

            //TicketRepository = Substitute.For<IRepository<Ticket>>();
            //container.Inject(typeof(IRepository<Ticket>), TicketRepository);

            DomainEvents.Container = container;
        }
    }
}