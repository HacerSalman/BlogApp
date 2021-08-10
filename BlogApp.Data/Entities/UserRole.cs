using BlogApp.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Entities
{
    [Table("user_role_tab")]
    public class UserRole:BaseEntity
    {
        [Column("role", TypeName = "VARCHAR(32)")]
        public Role.Values Role { get; set; }

        [Column("user_id")]
        public long UserId { get; set; }
        public User User { get; set; }

        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter, EnumToStringConverter<Role.Values> roleConverter)
        {
            FluentInit<UserRole>(modelBuilder, statusConverter);
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne<Role>().WithMany().HasForeignKey(ur => ur.Role).OnDelete(DeleteBehavior.Restrict);
                entity.Property(ur => ur.Role).HasConversion(roleConverter);
                entity.HasOne(ur => ur.User).WithMany(u => u.Roles).HasForeignKey(ur => ur.UserId).HasPrincipalKey(u => u.Id).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
