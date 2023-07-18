using NeDersinV2.DTOs.Abstract;

namespace NeDersinV2.DTOs.DTOs.GetModels
{
    public record class GetSurveyRatingDTO : IGetDTO
    {

        public int Id { get; init; }

        public int SurveyId { get; init; }

        public int? UserId { get; init; }

        public string? RatingText { get; init; }

        public int RatingCount { get; init; }
    }
}
