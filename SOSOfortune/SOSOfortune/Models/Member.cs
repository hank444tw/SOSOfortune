namespace SOSOfortune.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Member")]
    public partial class Member
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "必須輸入姓名!")]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "必須選擇性別!")]
        [Display(Name = "性別")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "必須輸入電子信箱!")]
        [Display(Name = "電子信箱")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "必須輸入手機號碼!")]
        [StringLength(10,MinimumLength = 10, ErrorMessage = "長度不符合手機10碼")]
        [Display(Name = "手機號碼")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "必須輸入帳號!")]
        [Display(Name = "帳號")]
        [Remote("CheckMemId", "Members", HttpMethod = "POST", ErrorMessage = "此帳號重複")]
        public string Mem_id { get; set; }

        [Required(ErrorMessage = "必須輸入密碼!")]
        [Display(Name = "密碼")]
        [DataType(DataType.Password,ErrorMessage = "請輸入正確的電子信箱")]
        public string Mem_password { get; set; }

        [Required]
        public string Mem_guid { get; set; }

        [Required]
        [StringLength(1)]
        public string Admin { get; set; }
    }
}
