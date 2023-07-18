using NeDersinV2.Entities.Abstract;

namespace NeDersinV2.Entities.Concrete;

public partial class Answer : IEntity
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public string? AnswerValue { get; set; }

    public string Type { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
