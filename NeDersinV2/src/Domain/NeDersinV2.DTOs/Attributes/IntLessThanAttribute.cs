using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.DTOs.Attributes
{
    public class IntLessThanAttribute : ValidationAttribute
    {
        private readonly int _maxValue;
        private readonly string? _variableName;

        public IntLessThanAttribute(int maxValue, string? variableName)
        {
            _maxValue = maxValue;
            _variableName = variableName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int intValue)
            {
                if (intValue > _maxValue)
                {
                    return new ValidationResult($"Değişken {_variableName} {_maxValue} değerinden küçük olmalı fakat sizinki {value}");
                }
            }
            return ValidationResult.Success;

        }
    }
}
