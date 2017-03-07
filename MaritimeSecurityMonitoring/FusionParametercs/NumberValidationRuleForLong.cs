using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;

namespace MaritimeSecurityMonitoring
{
    public class NumberValidationRuleForLong : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            long lnumber;
            if (!long.TryParse((string)value, out lnumber))
            {
                return new ValidationResult(false, "输入内容必须为整数！");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}