using NeDersinV2.DTOs.Abstract;

namespace NeDersinV2.DTOs.DTOs.GetModels
{
    public record class GetResponseDTO : IGetDTO
    {

        public int Id { get; init; }

        public string ResponseText { get; init; } = null!;

        public int QuestionId { get; init; }

        public int? UserId { get; init; }
    }
}
