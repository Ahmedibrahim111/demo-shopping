using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Models
{
    public class UserBill
    { 
    [Key]
        public int BillNumber { get; set; }
        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string PhoneNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<PaymentOrderDetails> PaymentOrderDetails { get; set; }

    }
}
