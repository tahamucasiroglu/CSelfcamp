using NeDersinV2.DTOs.Abstract;
using NeDersinV2.DTOs.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NeDersinV2.DTOs.ViewModels.Survey
{
    public sealed record class VM_Create_Survey : I_VM_Create
    {
        [Required(ErrorMessage = "aga sen kimsin")]
        [IntBiggerThan(0,null)]
        public int UserId { get; init; }

        [Required(ErrorMessage = "Başlık yok")]
        public string Title { get; init; } = null!;

        [Required(ErrorMessage = "Açıklama yok")]
        public string Describtion { get; init; } = null!;

        public DateTime? EndTime { get; init; }

        public int? MaxResponse { get; init; }

        public int? MinResponse { get; init; }
    }
}
