using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SOSOfortune.Models
{
    public partial class SOSOfortuneDataModel : DbContext
    {
        public SOSOfortuneDataModel()
            : base("name=SOSOfortuneContext") //���wWeb.Config������Ʈw�s�u
        {
        }

        public virtual DbSet<Member> Member { get; set; } //Entity Set���鶰

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Mem_id)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Mem_password)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Mem_guid)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Admin)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
