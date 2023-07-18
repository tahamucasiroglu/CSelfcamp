using NeDersinV2.DTOs.Abstract;
using NeDersinV2.DTOs.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NeDersinV2.DTOs.ViewModels.Survey
{
    public sealed record class VM_Update_Survey : I_VM_Update
    {
        [Required(ErrorMessage = "müneccim miyim ben ver şu id yi")]
        [IntBiggerThan(0,null)]
        public int Id { get; init; }

        public string? Title { get; init; } = null!;

        public string? Describtion { get; init; } = null!;

        public DateTime? EndTime { get; init; }

        public int? MaxResponse { get; init; }

        public int? MinResponse { get; init; }

        public double? Rating { get; set; }
    }
}
