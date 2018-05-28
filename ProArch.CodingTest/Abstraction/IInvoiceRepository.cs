using ProArch.CodingTest.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.CodingTest.Abstraction
{
    public interface IInvoiceRepository
    {
        IQueryable<Invoice> Get();
    }
}
