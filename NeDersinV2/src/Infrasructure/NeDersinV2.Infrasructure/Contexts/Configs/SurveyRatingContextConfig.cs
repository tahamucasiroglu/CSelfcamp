
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeDersinV2.Entities.Concrete;
namespace NeDersinV2.Infrasructure.Contexts.Configs
{
    public class SurveyRatingContextConfig : IEntityTypeConfiguration<SurveyRating>
    {
        public void Configure(EntityTypeBuilder<SurveyRating> entity)
        {
            entity.Property(e => e.RatingText).HasColumnType("text");

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyRatings)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SurveyRatings_Surveys");

            entity.HasOne(d => d.User).WithMany(p => p.SurveyRatings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_SurveyRatings_Users");
        }
    }
}
