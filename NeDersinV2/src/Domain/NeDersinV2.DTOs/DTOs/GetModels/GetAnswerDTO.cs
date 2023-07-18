using NeDersinV2.DTOs.Abstract;

namespace NeDersinV2.DTOs.DTOs.GetModels
{
    public record class GetAnswerDTO : IGetDTO
    {

        public int Id { get; init; }

        public int QuestionId { get; init; }

        public string? AnswerValue { get; init; }

        public string Type { get; init; } = null!;
    }
}
