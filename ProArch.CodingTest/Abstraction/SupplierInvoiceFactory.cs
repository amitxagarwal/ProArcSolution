using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.CodingTest.Summary;
using ProArch.CodingTest.Suppliers;

namespace ProArch.CodingTest.Abstraction
{
    class SupplierInvoiceFactory : ISupplierInvoice
    {
        public ISpendService GetSupplierInvoice(int supplierId)
        {
            SupplierService supplierService = new SupplierService();
            Supplier supplier = supplierService.GetById(supplierId);

            if (supplier.IsExternal)
            {
                return new ExternalSpendService(supplier);
            }
            else
            {
                return new InternalSpendService(supplier);
            }
        }
    }
}
