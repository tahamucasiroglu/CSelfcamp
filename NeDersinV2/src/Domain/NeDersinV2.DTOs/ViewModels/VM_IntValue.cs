using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.DTOs.ViewModels
{
    public sealed record class VM_IntValue
    {
        [Required]
        public int Value { get; init; }
    }
}
