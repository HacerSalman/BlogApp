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
    [Table("category_tab")]
    public class Category:BaseEntity
    {
        [Column("name")]
        [StringLength(256)]
        [Required]
        public string Name { get; set; }

        [Column("description")]
        [StringLength(1024)]
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter)
        {
            FluentInit<Category>(modelBuilder, statusConverter);
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(c => c.Name);
            });
        }
    }
}
