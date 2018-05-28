using ProArch.CodingTest.Abstraction;

using Unity;

namespace ProArch.CodingTest.Summary
{
    public class SpendService
    {
        public SpendSummary GetTotalSpend(int supplierId)
        {
            
            ISupplierInvoice supplierInvoiceFactory = new SupplierInvoiceFactory();
            
            ISpendService spendService = supplierInvoiceFactory.GetSupplierInvoice(supplierId);

            return spendService.GetTotalSpend();
            //return null;
        }
    }
}
