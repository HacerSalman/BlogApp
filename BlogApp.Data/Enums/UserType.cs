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
    [Table("user_type_tab")]
    public class UserType
    {
        [Column("v", TypeName = "VARCHAR(32)")]
        public Values V { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Values
        {
            ADMIN,
            MEMBER,
            GUEST
        }

        internal static EnumToStringConverter<Values> FluentInitAndSeed(ModelBuilder modelBuilder)
        {
            var converter = new EnumToStringConverter<Values>();
            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.V);
                entity.Property(e => e.V).HasConversion(converter);
            });
            var values = Enum.GetValues(typeof(Values)).Cast<Values>();
            foreach (var v in values)
            {
                modelBuilder.Entity<UserType>(entity =>
                {
                    entity.HasData(new UserType() { V = v });
                });
            }
            return converter;
        }
    }
}
