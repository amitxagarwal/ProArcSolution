using ProArch.CodingTest.Abstraction;
using ProArch.CodingTest.External;
using ProArch.CodingTest.Invoices;
using ProArch.CodingTest.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;


namespace ProArch.CodingTest.Summary
{
    public class ExternalSpendService : ISpendService
    {
        private Supplier _supplier;

        public ExternalSpendService(Supplier supplier)
        {
            _supplier = supplier;
        }

        public SpendSummary GetTotalSpend()
        {

            var watch = Stopwatch.StartNew();
            var tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;
            int counter = 1;
            ct.ThrowIfCancellationRequested();
            bool timeOut = true;


            
            Task<ExternalInvoice[]> tsk = new Task<ExternalInvoice[]>(() => ExternalInvoiceService.GetInvoices(_supplier.Id.ToString()), ct);
            tsk.Start();
            while (timeOut && counter<=3)
            {
                if (tsk.IsCompleted)
                {
                    timeOut = false;
                    break;
                }

                if (!(tsk.IsCompleted) && watch.ElapsedMilliseconds >= 30000)
                    tokenSource.Cancel();
                
                if (ct.IsCancellationRequested)
                {
                    try {
                        timeOut = false;
                        counter++;
                        ct.ThrowIfCancellationRequested(); }
                    catch
                    { }
                    finally
                    {
                        tokenSource = new CancellationTokenSource();
                        ct = tokenSource.Token;
                        watch.Restart();
                        tsk = new Task<ExternalInvoice[]>(() => ExternalInvoiceService.GetInvoices(_supplier.Id.ToString()), tokenSource.Token);
                        tsk.Start();
                    }                    
                }
            }            
            ExternalInvoice[] invoices = tsk.Result;

            if (invoices.Count() == 0)
            {
                FailoverInvoiceService failoverInvoiceService = new FailoverInvoiceService();
                FailoverInvoiceCollection collection = failoverInvoiceService.GetInvoices(_supplier.Id);
                invoices = collection.Invoices;
            }

            var sd = (from supplier in invoices
                      group supplier by supplier.Year into eGroup
                      select new SpendDetail()
                      {
                          Year = eGroup.Key,
                          TotalSpend = eGroup.Sum(x => x.TotalAmount)
                      });

            return new SpendSummary()
            {
                Name = _supplier.Name,
                Years = sd.ToList()
            };
        }
    }
}
