using NeDersinV2.DTOs.Abstract;

namespace NeDersinV2.DTOs.DTOs.GetModels
{
    public record class GetQuestionDTO : IGetDTO
    {

        public int Id { get; init; }

        public string QuestionText { get; init; } = null!;

        public string? FileAddress { get; init; }

        public int SurveyId { get; init; }
    }
}
