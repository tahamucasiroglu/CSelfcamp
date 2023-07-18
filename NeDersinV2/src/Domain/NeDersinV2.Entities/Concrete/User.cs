using NeDersinV2.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace NeDersinV2.Entities.Concrete;

public partial class User : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public string? IdentityNumber { get; set; }

    public DateTime? Birthdate { get; set; }

    public int? Age { get; set; }

    public int? Country { get; set; }

    public bool? Gender { get; set; }

    public string UserStatus { get; set; } = null!;

    public virtual ICollection<Response> Responses { get; set; } = new List<Response>();

    public virtual ICollection<SurveyRating> SurveyRatings { get; set; } = new List<SurveyRating>();
    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
