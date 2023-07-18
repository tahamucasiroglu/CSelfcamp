
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeDersinV2.Entities.Concrete;
namespace NeDersinV2.Infrasructure.Contexts.Configs
{
    public class ResponseContextConfig : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> entity)
        {
            entity.Property(e => e.ResponseText).HasColumnType("text");

            entity.HasOne(d => d.Question).WithMany(p => p.Responses)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Responses_Questions");

            entity.HasOne(d => d.User).WithMany(p => p.Responses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Responses_Users");
        }
    }
}
