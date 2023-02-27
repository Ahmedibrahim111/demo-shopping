using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.VM
{
    public class paymentVM
    {
        public int Id { get; set; }

        public string NameProduct { get; set; }
        public int BillId { get; set; }

        public int NumberProducts { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal Total { get; set; }

        public int BillNumber { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
