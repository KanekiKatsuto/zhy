using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace MaritimeSecurityMonitoring
{
    public class NumberValidationRuleForFloat : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            float fnumber;
            if (!float.TryParse((string)value, out fnumber))
            {
                return new ValidationResult(false, "输入内容必须为数值！");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
