using AngularApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models
{
    public class PaymentDetailContext : DbContext
    {
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options) : base(options)
        {

        }

        public DbSet<ItemMangement> itemMangements { get; set; }
        public DbSet<PaymentOrderDetails> paymentOrderDetails { get; set; }

        public DbSet<UserBill> userBills { get; set; }

    }
}
