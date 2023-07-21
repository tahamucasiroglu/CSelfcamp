using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.DTOs.ViewModels
{
    public sealed record class VM_PageValue
    {
        [Required]
        public int pageNumber { get; set; }
        [Required]
        public int pageSize { get; set; }
        public string order { get; set; } = string.Empty;
        public string shortType { get; set; } = string.Empty;
    }
}
