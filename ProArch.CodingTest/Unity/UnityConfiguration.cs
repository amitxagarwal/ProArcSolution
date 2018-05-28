using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using ProArch.CodingTest;
using ProArch.CodingTest.Abstraction;
using ProArch.CodingTest.Summary;
using Unity.Lifetime;
using ProArch.CodingTest.Invoices;

namespace ProArch.CodingTest.Unity
{
   public class UnityConfiguration
    {
        IUnityContainer container = null;
        public IUnityContainer ConfigureContainer()
        {
            container = new UnityContainer();

            container.RegisterType<ISpendService, ExternalSpendService>(new HierarchicalLifetimeManager());

            container.RegisterType<ISpendService, InternalSpendService>(new HierarchicalLifetimeManager());
            container.RegisterType<IInvoiceRepository, InvoiceRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISupplierInvoice, SupplierInvoiceFactory>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}
