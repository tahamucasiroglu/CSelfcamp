using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.DTOs.ViewModels.User
{
    public sealed record class VM_Update_UserStatus
    {
        public int Id { get; set; }

        public string UserStatus { get; set; } = null!;
    }
}
