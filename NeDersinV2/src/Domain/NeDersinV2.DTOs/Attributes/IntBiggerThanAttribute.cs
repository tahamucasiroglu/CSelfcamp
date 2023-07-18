using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.DTOs.Attributes
{
    public class IntBiggerThanAttribute : ValidationAttribute
    {
        private readonly int _minValue;
        private readonly string? _variableName;

        public IntBiggerThanAttribute(int minValue, string? variableName)
        {
            _minValue = minValue;
            _variableName = variableName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int intValue)
            {
                if (intValue < _minValue)
                {
                    return new ValidationResult($"Değişken {_variableName} {_minValue} değerinden büyük olmalı fakat sizin değeriniz {intValue}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
