using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() //ctor
        {
            RuleFor(p => p.ProductName).NotEmpty(); // ProductNAme boş olamaz.
            RuleFor(p => p.ProductName).MinimumLength(2); // ProductName 2 karakterden küçük olamaz.
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0); // UnitPrice 0'dan büyük olmalı.
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); // 1 numaralı kategorideki ürünlerin min fiyatı 10 olöalıdır.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün isimleri A harfi ile başlamalıdır."); 
            // ProductName A ile başlamalı. Bu hazır kod değil biz oluşturduk.
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A"); // A ile başlıyorsa True döner. Aksi halde False.
        }
    }
}
