using NeDersinV2.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace NeDersinV2.Entities.Concrete;

public partial class Response : IEntity
{
    public int Id { get; set; }

    public string ResponseText { get; set; } = null!;

    public int QuestionId { get; set; }

    public int? UserId { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual User? User { get; set; }
}
