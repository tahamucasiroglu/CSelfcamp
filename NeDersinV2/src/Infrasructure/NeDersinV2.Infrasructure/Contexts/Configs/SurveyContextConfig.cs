
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeDersinV2.Entities.Concrete;
namespace NeDersinV2.Infrasructure.Contexts.Configs
{
    public class SurveyContextConfig : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> entity)
        {
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Describtion).HasColumnType("text");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
            
        }
    }
}
