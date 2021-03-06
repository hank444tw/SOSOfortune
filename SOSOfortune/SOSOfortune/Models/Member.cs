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

        [Required(ErrorMessage = "請輸入姓名!")]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "請選擇性別!")]
        [Display(Name = "性別")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "請輸入電子信箱!")]
        [Display(Name = "電子信箱")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "請輸入手機號碼!")]
        [StringLength(10,MinimumLength = 10, ErrorMessage = "長度不符合手機10碼")]
        [Display(Name = "手機號碼")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "請輸入帳號!")]
        [Display(Name = "帳號")]
        [Remote("CheckMemId", "Members", HttpMethod = "POST", ErrorMessage = "此帳號重複")]
        public string Mem_id { get; set; }

        [Required(ErrorMessage = "請輸入密碼!")]
        [Display(Name = "密碼")]
        [DataType(DataType.Password,ErrorMessage = "請輸入正確的電子信箱")]
        public string Mem_password { get; set; }

        [Required(ErrorMessage = "請再重新輸入一次密碼!")]
        [Display(Name = "確認密碼")]
        [System.Web.Mvc.Compare("Mem_password",ErrorMessage = "兩次輸入的密碼必須一樣")]
        public string Mem_confirmPassword { get; set; }

        [Required(ErrorMessage = "請輸入生日!")]
        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public string Mem_guid { get; set; }

        [StringLength(1)]
        public string Admin { get; set; }
    }
}
