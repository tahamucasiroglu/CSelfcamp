using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NeDersinV2.Entities.Concrete;

namespace NeDersinV2.Infrasructure.Contexts;

public partial class NeDersinV2Context : DbContext
{
    public NeDersinV2Context()
    {
    }

    public NeDersinV2Context(DbContextOptions<NeDersinV2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Response> Responses { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<SurveyRating> SurveyRatings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=NeDersinV2; Trusted_Connection=True;")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Turkish_CS_AS");
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
