using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProArch.CodingTest;
using ProArch.CodingTest.Summary;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod_External()
        {
            int supplierId = 1;
            List<SpendDetail> sd = new List<SpendDetail>();
            sd.Add(new SpendDetail() { TotalSpend = 5000, Year = DateTime.Now.Year });
            sd.Add(new SpendDetail() { TotalSpend = 7000, Year = DateTime.Now.AddYears(-1).Year });
            sd.Add(new SpendDetail() { TotalSpend = 8000, Year = DateTime.Now.AddYears(-2).Year });
            sd.Add(new SpendDetail() { TotalSpend = 9000, Year = DateTime.Now.AddYears(-3).Year });
            SpendSummary expectedspsum = new SpendSummary() { Name = "Bob", Years = sd};
            SpendSummary actualspsum = new SpendSummary();

           

            actualspsum = new SpendService().GetTotalSpend(supplierId);
            Assert.AreEqual(expectedspsum.Name, actualspsum.Name);
            if (expectedspsum.Years.Count == actualspsum.Years.Count)
            {
                foreach(SpendDetail  spd in actualspsum.Years)
                {
                    Assert.IsNotNull(expectedspsum.Years.Find(x => x.TotalSpend==spd.TotalSpend && x.Year==spd.Year));                  
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestMethod_Internal()
        {
            int supplierId = 2;            

            List<SpendDetail> sd = new List<SpendDetail>();
            sd.Add(new SpendDetail() { TotalSpend = 17000, Year = DateTime.Now.Year });
            
            sd.Add(new SpendDetail() { TotalSpend = 15000, Year = DateTime.Now.AddYears(-1).Year });
           
            sd.Add(new SpendDetail() { TotalSpend = 10000, Year = DateTime.Now.AddYears(-5).Year });
            
            SpendSummary expectedspsum = new SpendSummary() { Name = "Tom", Years = sd };
            SpendSummary actualspsum = new SpendSummary();

            actualspsum = new SpendService().GetTotalSpend(supplierId);
            Assert.AreEqual(expectedspsum.Name, actualspsum.Name);
            if (expectedspsum.Years.Count == actualspsum.Years.Count)
            {
                foreach (SpendDetail spd in actualspsum.Years)
                {
                    Assert.IsNotNull(expectedspsum.Years.Find(x => x.TotalSpend == spd.TotalSpend && x.Year == spd.Year));
                }
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}
