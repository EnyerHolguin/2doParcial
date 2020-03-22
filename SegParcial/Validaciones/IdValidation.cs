using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace SegParcial.Validaciones
{
    class IdValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(value);
                }
                catch (FormatException)
                {
                    return new ValidationResult(false, "Debe ser un Numero Entero");
                }

                if (id >= 0)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "Debe ser igual o mayor que 0");
            }
            return new ValidationResult(false, "Debes Poner Id");
        }

        
    }
}
