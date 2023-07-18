using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersinV2.DTOs.Attributes
{
    public class IntRangeAttribute : ValidationAttribute
    {
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly string? _variableName;

        public IntRangeAttribute(int minValue, int maxValue, string? variableName)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _variableName = variableName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int intValue)
            {
                if (intValue < _minValue || intValue > _maxValue)
                {
                    return new ValidationResult($"Değişken {_variableName} {_minValue} - {_maxValue} arasında olmalı faakt sizinki {value}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
