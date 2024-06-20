using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adi bos gecilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Gorsel Alani Bos Gecilemez");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Gorsel Alani Bos Gecilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Alani Bos Gecilemez");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Deger Alani Bos Gecilemez");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("EN AZ 5 Karakterden olusmali ");
        }
    }
}
