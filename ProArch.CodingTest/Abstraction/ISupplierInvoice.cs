using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.CodingTest.Suppliers;
using ProArch.CodingTest.Summary;

namespace ProArch.CodingTest.Abstraction
{
    public interface ISupplierInvoice
    {
        ISpendService GetSupplierInvoice(int supplierId);
    }
}
