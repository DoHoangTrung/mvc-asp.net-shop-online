namespace Hoc_ASP.NET_MVC.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            Orders = new HashSet<Order>();
        }

        public int id { get; set; }

        public DateTime createAt { get; set; }

        public int? statusId { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        public int? accountId { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(200)]
        public string orderAddress { get; set; }

        [StringLength(10)]
        public string phone { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual TransactionStatu TransactionStatu { get; set; }
    }
}
