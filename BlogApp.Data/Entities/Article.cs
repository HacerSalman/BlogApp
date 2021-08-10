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
    [Table("article_tab")]
    public class Article:BaseEntity
    {
        [Column("title")]
        [StringLength(512)]
        [Required]
        public string Title { get; set; }

        [Column("content")]
        [Required]
        public string Content { get; set; }

        [Column("thumbnail")]
        [StringLength(512)]
        [Required]
        public string Thumbnail { get; set; }

        [Column("view_count")]
        public long ViewCount { get; set; } = 0;

        [Column("comment_count")]
        public long CommentCount { get; set; } = 0;

        [Column("seo_author")]
        [StringLength(512)]
        public string SeoAuthor { get; set; }

        [Column("seo_description")]
        [StringLength(2048)]
        public string SeoDescription { get; set; }

        [Column("seo_tags")]
        [StringLength(1024)]
        public string SeoTags { get; set; }

        [Column("category_id")]
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        [Column("user_id")]
        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter)
        {
            FluentInit<Article>(modelBuilder, statusConverter);
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasOne(a => a.User).WithMany( u => u.Articles).HasForeignKey(a =>a.UserId).HasPrincipalKey(u => u.Id).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId).HasPrincipalKey(c => c.Id).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(a => a.Title);
                entity.HasIndex(a => a.SeoAuthor);
            });
        }
    }
}
