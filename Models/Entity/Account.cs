namespace Hoc_ASP.NET_MVC.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(200)]
        public string nameLogin { get; set; }

        [StringLength(100)]
        public string passWord { get; set; }

        public int? typeId { get; set; }

        public virtual AccountType AccountType { get; set; }
    }
}
