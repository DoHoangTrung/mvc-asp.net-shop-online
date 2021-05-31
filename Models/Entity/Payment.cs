namespace Hoc_ASP.NET_MVC.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int id { get; set; }

        public int? idOrderStatus { get; set; }

        public DateTime? paidDate { get; set; }

        public int? idCustomer { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual OrderStatu OrderStatu { get; set; }
    }
}
