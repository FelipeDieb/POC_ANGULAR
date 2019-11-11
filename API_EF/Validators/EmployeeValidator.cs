using FluentValidation;
using PocAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocAPI.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).MaximumLength(200).NotNull();
            RuleFor(x => x.Salary).GreaterThanOrEqualTo(0).NotNull();
            RuleFor(x => x.StartMonth).Must(month => Enum.GetValues(typeof(Month)).Cast<int>().Contains((int)month));
            RuleFor(x => x.Departament).NotNull();
        }
    }
}
