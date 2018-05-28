using ProArch.CodingTest.Abstraction;
using ProArch.CodingTest.Invoices;
using ProArch.CodingTest.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.CodingTest.Summary
{
    public class InternalSpendService : ISpendService
    {
        private IInvoiceRepository _invoiceRepository;
        private Supplier _supplier;

        public InternalSpendService(Supplier supplier)
        {
            _supplier = supplier;
            _invoiceRepository =  new InvoiceRepository();
        }

        public SpendSummary GetTotalSpend()
        {
            var SpendDetail = (from supplier in _invoiceRepository.Get()
                         where supplier.SupplierId == _supplier.Id
                         group supplier by supplier.InvoiceDate.Year into eGroup
                         select new SpendDetail()
                         {
                             Year = eGroup.Key,
                             TotalSpend = eGroup.Sum(x => x.Amount)
                         });

            return new SpendSummary()
            {
                Name = _supplier.Name,
                Years = SpendDetail.ToList()
            };
        }
    }
}
