using NeDersinV2.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace NeDersinV2.Entities.Concrete;

public partial class Question : IEntity
{
    public int Id { get; set; }

    public string QuestionText { get; set; } = null!;

    public string? FileAddress { get; set; }

    public int SurveyId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Response> Responses { get; set; } = new List<Response>();

    public virtual Survey Survey { get; set; } = null!;
}
