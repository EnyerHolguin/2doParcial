using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace SegParcial.Validaciones
{
    class SolucionValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                string solucion = Convert.ToString(value);

                if (solucion.Length <= 0)
                    return new ValidationResult(false, "Debes poner una Solucion");

                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Debe Tener un Campo");
        }

       
    }
}
