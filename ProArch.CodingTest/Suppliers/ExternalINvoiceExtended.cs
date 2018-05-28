using ProArch.CodingTest.External;
using ProArch.CodingTest.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.CodingTest.Suppliers
{
    public class ExternalInvoiceExtended:ExternalInvoice
    {
        private Supplier _supplier;
        private ExternalInvoice[] _externalInvoice;
        

        public ExternalInvoiceExtended(Supplier supplier)
        {
            _supplier = supplier;
            _externalInvoice = ExternalInvoiceService.GetInvoices(_supplier.Id.ToString());
        }
        
    }
}
