using FinanceiroApi.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceiroApi.SyntaxValidators
{
    public class LancamentoDtoValidator : AbstractValidator<LancamentoDto>
    {
        public LancamentoDtoValidator()
        {
            var _tiposPermitidos = new List<char>() { 'c','d' };
            RuleFor(x => x.Valor).GreaterThan(0).WithMessage("Valor deve ser maior que Zero (0)");
            RuleFor(x => x.Tipo).Must(_tiposPermitidos.Contains).WithMessage("Tipo deve ser: " + String.Join(",", _tiposPermitidos));
        }
    }
}
