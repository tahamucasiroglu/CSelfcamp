using NeDersinV2.DTOs.Abstract;
using NeDersinV2.DTOs.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NeDersinV2.DTOs.ViewModels.Question
{
    public sealed record class VM_Update_Question : I_VM_Update
    {
        [Required(ErrorMessage = "idsiz olmaz")]
        [IntBiggerThan(0,"")]
        public int Id { get; init; }

        public string? QuestionText { get; init; } = null!;

        public string? FileAddress { get; init; }
    }
}
