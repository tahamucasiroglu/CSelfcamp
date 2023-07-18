using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeDersinV2.Entities.Concrete;
namespace NeDersinV2.Infrasructure.Contexts.Configs
{
    public class QuestionContextConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> entity)
        {
            entity.Property(e => e.QuestionText).HasColumnType("text");
            entity.Property(e => e.FileAddress)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Survey).WithMany(p => p.Questions)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_Surveys");
        }
    }
}
