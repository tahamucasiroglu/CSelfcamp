using NeDersinV2.DTOs.Abstract;

namespace NeDersinV2.DTOs.DTOs.GetModels
{
    public record class GetUserDTO : IGetDTO
    {
        //public GetUserDTO(int ıd, string name, string surname, string email, string password, string? phone, string? ıdentityNumber, DateTime? birthdate, int? age, int? country, bool? gender, string userStatus)
        //{
        //    Id = ıd;
        //    Name = name;
        //    Surname = surname;
        //    Email = email;
        //    Password = password;
        //    Phone = phone;
        //    IdentityNumber = ıdentityNumber;
        //    Birthdate = birthdate;
        //    Age = age;
        //    Country = country;
        //    Gender = gender;
        //    UserStatus = userStatus;
        //}

        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public string Surname { get; init; } = null!;

        public string Email { get; init; } = null!;

        public string Password { get; init; } = null!;

        public string? Phone { get; init; }

        public string? IdentityNumber { get; init; }

        public DateTime? Birthdate { get; init; }

        public int? Age { get; init; }

        public int? Country { get; init; }

        public bool? Gender { get; init; }

        public string UserStatus { get; init; } = null!;
    }
}
