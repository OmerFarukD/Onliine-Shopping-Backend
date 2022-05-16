using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ClothesValidator :AbstractValidator<Clothes>
    {
        public ClothesValidator()
        {
            RuleFor(c => c.ClothesName).MinimumLength(3);
            RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(10);
        }
    }
}
