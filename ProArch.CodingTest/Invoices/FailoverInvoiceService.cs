using System;

namespace ProArch.CodingTest.Invoices
{
    public class FailoverInvoiceService
    {
        StorageRepository _storageRepository;

        public FailoverInvoiceService()
        {
            _storageRepository = new StorageRepository();
        }

        public FailoverInvoiceCollection GetInvoices(int supplierId)
        {
            FailoverInvoiceCollection collection = _storageRepository.Get();
            if (DateTime.Now.Year - collection.Timestamp.Year == 0 && DateTime.Now.Month - collection.Timestamp.Month <= 1)
                return collection;
            else
                return new FailoverInvoiceCollection();
        }
    }
}
