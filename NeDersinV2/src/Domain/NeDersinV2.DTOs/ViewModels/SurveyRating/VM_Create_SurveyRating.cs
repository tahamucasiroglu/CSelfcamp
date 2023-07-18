using NeDersinV2.DTOs.Abstract;
using NeDersinV2.DTOs.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NeDersinV2.DTOs.ViewModels.SurveyRating
{
    public sealed record class VM_Create_SurveyRating : I_VM_Create
    {
        [Required(ErrorMessage = "Kardeşim bu hangi anketin")]
        [IntBiggerThan(0,null)]
        public int SurveyId { get; init; }

        public int? UserId { get; init; }

        public string? RatingText { get; init; }

        [Required(ErrorMessage = "Kardeşim bu hangi anketin")]
        [IntRange(-1, 11, null)]
        public int RatingCount { get; init; }
    }
}
