using NeDersinV2.DTOs.Abstract;
using NeDersinV2.DTOs.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NeDersinV2.DTOs.ViewModels.Answer
{
    public sealed partial record VM_Create_Answer : I_VM_Create
    {
        [Required(ErrorMessage = "Bu cevabı nereye ekleyeyim")]
        [IntBiggerThan(0, $"{nameof(VM_Create_Answer)} -> {nameof(QuestionId)}")]
        public int QuestionId { get; init; }

        public string? AnswerValue { get; init; }
        [Required(ErrorMessage = "Bu cevabın tipi ne?")]
        public string Type { get; init; } = null!;
    }
}
