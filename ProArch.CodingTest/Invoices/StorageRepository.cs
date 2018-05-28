using ProArch.CodingTest.External;
using ProArch.CodingTest.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.CodingTest.Invoices
{
    public class StorageRepository
    {
        public FailoverInvoiceCollection Get()
        {
            ExternalInvoice[] Invoices = new ExternalInvoice[] {
               new ExternalInvoice() { TotalAmount = 5000, Year = DateTime.Now.Year },
               new ExternalInvoice() { TotalAmount=7000, Year= DateTime.Now.AddYears(-1).Year},
               new ExternalInvoice() { TotalAmount=8000, Year= DateTime.Now.AddYears(-2).Year},
               new ExternalInvoice() { TotalAmount=9000, Year= DateTime.Now.AddYears(-3).Year}               
            };
            FailoverInvoiceCollection collection = new FailoverInvoiceCollection()
            {
                Timestamp = DateTime.Now,
                Invoices = Invoices
            };

            return collection;
        }
    }
}
