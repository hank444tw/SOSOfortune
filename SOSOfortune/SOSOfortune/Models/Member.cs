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

        [Required(ErrorMessage = "������J�m�W!")]
        [Display(Name = "�m�W")]
        public string Name { get; set; }

        [Required(ErrorMessage = "������ܩʧO!")]
        [Display(Name = "�ʧO")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "������J�q�l�H�c!")]
        [Display(Name = "�q�l�H�c")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "������J������X!")]
        [StringLength(10,MinimumLength = 10, ErrorMessage = "���פ��ŦX���10�X")]
        [Display(Name = "������X")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "������J�b��!")]
        [Display(Name = "�b��")]
        [Remote("CheckMemId", "Members", HttpMethod = "POST", ErrorMessage = "���b������")]
        public string Mem_id { get; set; }

        [Required(ErrorMessage = "������J�K�X!")]
        [Display(Name = "�K�X")]
        [DataType(DataType.Password,ErrorMessage = "�п�J���T���q�l�H�c")]
        public string Mem_password { get; set; }

        [Required]
        public string Mem_guid { get; set; }

        [Required]
        [StringLength(1)]
        public string Admin { get; set; }
    }
}
