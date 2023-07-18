using NeDersinV2.DTOs.Abstract;
using NeDersinV2.DTOs.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NeDersinV2.DTOs.ViewModels.Answer
{
    public sealed record class VM_Update_Answer : I_VM_Update
    {
        [Required(ErrorMessage = "Bu cevabı nereye ekleyeyim")]
        [IntBiggerThan(0, $"{nameof(VM_Update_Answer)} -> {nameof(Id)}")]
        public int Id { get; init; }

        public string? AnswerValue { get; init; }
    }
}
