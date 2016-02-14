// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using TicketSales.Events.Data;
using TicketSales.Events.Data.Specifications;
using TicketSales.Events.Domain;
using TicketSales.Events.Queries;
using TicketSales.Infrastructure;
using TicketSales.Infrastructure.Data;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Data;
using TicketSales.Purchasing.Domain;
using TicketSales.Purchasing.Domain.Events;
using TicketSales.Purchasing.Domain.Handlers;
using TicketSales.Purchasing.Queries;
using TicketSales.Web.Controllers;

namespace TicketSales.Web.DependencyResolution
{
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });

            For<IBoxOffice>().Use<BoxOffice>();

            For<IHandle<TicketsPurchasedEvent>>()
                .Use<TicketsPurchasedUpdateInventoryHandler>();

            For<IHandle<TicketsPurchasedEvent>>()
                .Use<TicketsPurchasedEmailConfirmationHandler>();

            For<ISpecification<Event>>().Use<EventsByIdSpecification>();

            For<IQuery<int, Ticket>>().Use<AvailableTicketsQuery>();
            For<IQuery<string, Event>>().Use<EventsQuery>();
            For<IQuery<int, Event>>().Use<EventByIdQuery>();
            For<IQuery<int, Order>>().Use<OrdersQuery>();

            For<IGetAll<Event>>().Use<EventRepository>();
            For<IGetAll<Ticket>>().Use<TicketRepository>();
            For<IDelete<Ticket>>().Use<TicketRepository>();
            For<IGetAll<Order>>().Use<OrderRepository>();
            For<ICreate<Order>>().Use<OrderRepository>();

            For<ICreateTestData>().Use<EventsTestDataCreator>();
            For<ICreateTestData>().Use<TicketsTestDataCreator>();
        }

        #endregion
    }
}