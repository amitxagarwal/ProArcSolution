using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;
using ProArch.CodingTest.Abstraction;

namespace ProArch.CodingTest.Invoices
{
    public class InvoiceRepository : IInvoiceRepository
    {
        //Hardcoded data
        private List<Invoice> invoiceList = new List<Invoice>()
        {
            //Supplier 1
            new Invoice () { SupplierId = 1, Amount=5000, InvoiceDate= DateTime.Now},
            new Invoice () { SupplierId = 1, Amount=2000, InvoiceDate= DateTime.Now},
            new Invoice () { SupplierId = 1, Amount=3000, InvoiceDate=DateTime.Now.AddYears(-1)},
            new Invoice () { SupplierId = 1, Amount=7000, InvoiceDate=DateTime.Now.AddYears(-1)},
            new Invoice () { SupplierId = 1, Amount=4000, InvoiceDate=DateTime.Now.AddYears(-5)},
            new Invoice () { SupplierId = 1, Amount=2000, InvoiceDate=DateTime.Now.AddYears(-5)},

            //Supplier 2
            new Invoice () { SupplierId = 2, Amount=7000, InvoiceDate= DateTime.Now},
            new Invoice () { SupplierId = 2, Amount=10000, InvoiceDate= DateTime.Now},
            new Invoice () { SupplierId = 2, Amount=8000, InvoiceDate=DateTime.Now.AddYears(-1)},
            new Invoice () { SupplierId = 2, Amount=7000, InvoiceDate=DateTime.Now.AddYears(-1)},
            new Invoice () { SupplierId = 2, Amount=9000, InvoiceDate=DateTime.Now.AddYears(-5)},
            new Invoice () { SupplierId = 2, Amount=1000, InvoiceDate=DateTime.Now.AddYears(-5)}
        };
        public IQueryable<Invoice> Get()
        {
            return invoiceList.AsQueryable();
            //return new List<Invoice>().AsQueryable();
        }
    }
}
