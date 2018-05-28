using ProArch.CodingTest.Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.CodingTest.Abstraction
{
    public interface ISpendService
    {
        SpendSummary GetTotalSpend();
    }
}
