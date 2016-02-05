using StructureMap;
using TicketSales.Web.DependencyResolution;

namespace TicketSales.Specs
{
    public class IntegrationTestBase
    {
        private IContainer container;
        public IContainer Container
        {
            get {return container; }
        }

        public IntegrationTestBase()
        {
            container = IoC.Initialize();
        } 
    }
}