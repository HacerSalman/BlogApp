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
    [Table("comment_tab")]
    public class Comment:BaseEntity
    {
        [Column("text")]
        [Required]
        public string Text { get; set; }

        [Column("article_id")] 
        public long ArticleId { get; set; }
        public Article Article { get; set; }
        [Column("parent_id")]
        public long? ParentId { get; set; }

        public Comment Parent { get; set; }
        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter)
        {
            FluentInit<Comment>(modelBuilder, statusConverter);
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId).HasPrincipalKey(a => a.Id).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(c => c.Parent).WithMany().HasForeignKey(c => c.ParentId).HasPrincipalKey(p => p.Id).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
