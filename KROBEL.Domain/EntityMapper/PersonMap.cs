using KROBEL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KROBEL.Domain.EntityMapper
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_personid");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .HasColumnType("INT");

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("last_name")
                .HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.BirthDate)
                .IsRequired()
                .HasColumnName("birth_date")
                .HasColumnType("datetime");

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasColumnName("phone_number")
                .HasColumnType("NVARCHAR(20)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("NVARCHAR(100)");

            builder.Property(x => x.Gender)
                .IsRequired()
                .HasColumnName("gender")
                .HasColumnType("NVARCHAR(10)");

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnName("created_date")
                .HasColumnType("datetime");

            builder.Property(x => x.ModifiedDate)
                .IsRequired()
                .HasColumnName("modified_date")
                .HasColumnType("datetime");

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("is_active")
                .HasColumnType("bit");

            builder.ToTable("Person");
        }
    }
}
