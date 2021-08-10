using BlogApp.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Enums
{
    [Table("role_tab")]
    public class Role
    {
        [Column("v", TypeName = "VARCHAR(32)")]
        public Values V { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Values
        {
            BLOG_WRITE,
            BLOG_READ,
            COMMENT_WRITE,
            COMMENT_READ
        }

        internal static EnumToStringConverter<Values> FluentInitAndSeed(ModelBuilder modelBuilder)
        {
            var converter = new EnumToStringConverter<Values>();
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.V);
                entity.Property(e => e.V).HasConversion(converter);
            });
            var values = Enum.GetValues(typeof(Values)).Cast<Values>();
            foreach (var v in values)
            {
                modelBuilder.Entity<Role>(entity =>
                {
                    entity.HasData(new Role() { V = v });
                });
            }
            return converter;
        }

    }
}
