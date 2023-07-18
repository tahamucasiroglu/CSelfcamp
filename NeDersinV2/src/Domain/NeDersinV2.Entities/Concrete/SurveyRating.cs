using NeDersinV2.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace NeDersinV2.Entities.Concrete;

public partial class SurveyRating : IEntity
{
    public int Id { get; set; }

    public int SurveyId { get; set; }

    public int? UserId { get; set; }

    public string? RatingText { get; set; }

    public int RatingCount { get; set; }

    public virtual Survey Survey { get; set; } = null!;

    public virtual User? User { get; set; }
}
