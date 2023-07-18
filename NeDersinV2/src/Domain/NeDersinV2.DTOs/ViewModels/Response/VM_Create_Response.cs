using NeDersinV2.DTOs.Abstract;
using NeDersinV2.DTOs.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NeDersinV2.DTOs.ViewModels.Response
{
    public sealed record class VM_Create_Response : I_VM_Create
    {
        [Required(ErrorMessage = "cevabın yok")]
        public string ResponseText { get; init; } = null!;
        [Required(ErrorMessage = "hangi soruya cevap verdin")]
        [IntBiggerThan(0,"")]
        public int QuestionId { get; init; }

        public int? UserId { get; init; }
    }
}
