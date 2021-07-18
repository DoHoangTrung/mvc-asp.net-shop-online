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
        [Required(ErrorMessage ="Ban chua nhap ten tai khoan")]
        [Key]
        [StringLength(200)]
        public string userName { get; set; }

        [Required(ErrorMessage = "Ban chua nhap mat khau")]
        [StringLength(100)]
        public string passWord { get; set; }

        public int? typeId { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        public DateTime? dateOfBirth { get; set; }
        
        [EmailAddress]
        [StringLength(200)]
        public string email { get; set; }

        [Phone(ErrorMessage ="Ban da nhap sai so dien thoai")]
        [StringLength(10)]
        public string phone { get; set; }

        public virtual AccountType AccountType { get; set; }
    }
}
