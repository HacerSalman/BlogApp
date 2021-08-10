using BlogApp.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Entities
{
    [Table("user_tab")]
    public class User:BaseEntity
    {
        [Column("name")]
        [StringLength(512)]
        public string Name { get; set; }

        [Column("surname")]
        [StringLength(512)]
        public string Surname { get; set; }

        [Column("surname")]
        [StringLength(512)]
        public string Picture { get; set; }

        public ICollection<Article> Articles { get; set; }

        [Column("user_type", TypeName = "VARCHAR(32)")]
        public UserType.Values Type { get; set; }

        [Column("username")]
        [StringLength(128)]
        [Required]
        public Guid Username { get; set; } = Guid.NewGuid();

        [Column("email")]
        [StringLength(512)]
        public string Email { get; set; }

        [Column("password")]
        [StringLength(1024)]
        public string Password { get; set; }

        public ICollection<UserRole> Roles { get; set; }

        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter, EnumToStringConverter<UserType.Values> typeConverter)
        {
            FluentInit<User>(modelBuilder, statusConverter);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Name);
                entity.HasIndex(u => u.Email);
                entity.HasIndex(u => u.Username).IsUnique();
                entity.HasOne<UserType>().WithMany().HasForeignKey(u => u.Type).OnDelete(DeleteBehavior.Restrict);
                entity.Property(u => u.Type).HasConversion(typeConverter);
            });
        }
    }
}
