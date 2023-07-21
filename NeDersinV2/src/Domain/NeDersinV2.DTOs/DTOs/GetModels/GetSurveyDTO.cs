using NeDersinV2.DTOs.Abstract;

namespace NeDersinV2.DTOs.DTOs.GetModels
{
    public record class GetSurveyDTO : IGetDTO
    {

        public int Id { get; init; }

        public Guid Address { get; init; }

        public int UserId { get; init; }

        public string Title { get; init; } = null!;

        public string Describtion { get; init; } = null!;

        public DateTime Date { get; init; }

        public bool IsEnd { get; init; }

        public DateTime? EndTime { get; init; }

        public int? MaxResponse { get; init; }

        public int? MinResponse { get; init; }
        public int ResponseCount { get; set; }

        public int ViewCount { get; set; }

        public double Rating { get; set; }
    }
}
