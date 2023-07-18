
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeDersinV2.Entities.Concrete;
namespace NeDersinV2.Infrasructure.Contexts.Configs
{
    public class UserContextConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdentityNumber)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserStatus)
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
