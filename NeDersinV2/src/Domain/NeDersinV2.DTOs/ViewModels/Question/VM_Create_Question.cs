using NeDersinV2.DTOs.Abstract;
using NeDersinV2.DTOs.Attributes;
using NeDersinV2.DTOs.ViewModels.Answer;
using System.ComponentModel.DataAnnotations;

namespace NeDersinV2.DTOs.ViewModels.Question
{
    public sealed record class VM_Create_Question : I_VM_Create
    {
        [Required(ErrorMessage = "bu sorunun sorusu nerede")]
        [StringLength(100, ErrorMessage = "soruda biraz uzun olmalı")]
        public string QuestionText { get; init; } = null!;

        public string? FileAddress { get; init; }

        [Required(ErrorMessage = "lazım")]
        [IntBiggerThan(0, "soruyu nereye ekleyeceğim")]
        public int SurveyId { get; init; }
    }
}
