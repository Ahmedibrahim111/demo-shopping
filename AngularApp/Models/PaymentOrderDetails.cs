using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Models
{
    public class PaymentOrderDetails
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string NameProduct { get; set; }
        [ForeignKey("UserBill")]
        public int BillId { get; set; }

        public int NumberProducts { get; set; }
        public decimal Price { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        public int Size { get; set; }
        [Column(TypeName = "nvarchar(150)")]

        public decimal TotalPrice { get; set; }
        public UserBill UserBill { get; set; }
    }
}
