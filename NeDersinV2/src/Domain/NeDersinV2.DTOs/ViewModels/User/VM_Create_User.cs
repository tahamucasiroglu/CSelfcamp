using NeDersinV2.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.DTOs.ViewModels.User
{
    public sealed record class VM_Create_User : I_VM_Create
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Phone { get; set; }

        public string? IdentityNumber { get; set; }

        public DateTime? Birthdate { get; set; }

        public int? Age { get; set; }

        public int? Country { get; set; }

        public bool? Gender { get; set; }

        public string UserStatus { get; set; } = null!;
    }
}
