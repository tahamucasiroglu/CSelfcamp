using NeDersinV2.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace NeDersinV2.Entities.Concrete;

public partial class Survey : IEntity
{
    public int Id { get; set; }

    public Guid Address { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Describtion { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool IsEnd { get; set; }

    public DateTime? EndTime { get; set; }

    public int? MaxResponse { get; set; }

    public int? MinResponse { get; set; }

    public int ResponseCount { get; set; }

    public int ViewCount { get; set; }

    public double Rating { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<SurveyRating> SurveyRatings { get; set; } = new List<SurveyRating>();
    public virtual User User { get; set; } = null!;
}
