using System.Collections.Generic;
using System.Linq;

namespace ProArch.CodingTest.Suppliers
{
    public class SupplierService
    {
        //HardCoded data
        private static List<Supplier> suppliersList = new List<Supplier> {

            new Supplier() { Id = 1, Name = "Bob", IsExternal = true},
            new Supplier() { Id = 2, Name = "Tom", IsExternal = false}
        };

        public Supplier GetById(int id)
        {
            return suppliersList.SingleOrDefault(x => x.Id == id);
        }
    }
}
