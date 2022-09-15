using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        // validation kuralları constructor içine yazarız

        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c=>c.DailyPrice).GreaterThanOrEqualTo(10).When(c=>c.BrandId==1); //1 Numaralı markalılarda günlük ücret 10dan büyük olmalı.
            RuleFor(c => c.CarName).Must(StartWithA).WithMessage("Araba ismi A ile başlamalı"); //kendi kuralımızı böyle koyabiliriz.
        
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
