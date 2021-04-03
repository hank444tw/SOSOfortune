namespace SOSOfortune.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Member")]
    public partial class Member
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        public string Mem_id { get; set; }

        [Required]
        public string Mem_password { get; set; }

        [Required]
        public string Mem_guid { get; set; }

        [Required]
        [StringLength(1)]
        public string Admin { get; set; }
    }
}
