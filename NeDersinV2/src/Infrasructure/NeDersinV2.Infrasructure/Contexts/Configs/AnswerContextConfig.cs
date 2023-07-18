using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeDersinV2.Entities.Concrete;

namespace NeDersinV2.Infrasructure.Contexts.Configs
{
    public class AnswerContextConfig : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> entity)
        {
            entity.Property(e => e.AnswerValue).HasColumnType("text");
            entity.Property(e => e.Type).HasColumnType("text");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Answers_Questions");
            
        }
    }
}
