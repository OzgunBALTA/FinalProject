using Castle.DynamicProxy;
using Core.CrossCuttingConcers.Validation.FluentValidation;
using Core.Utilities.Interceptors.Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //Gönderilen type IValidator tipinde değilse hata mesajı ver.
            {
                throw new System.Exception("Bu bir Attribute değil");
            }

            _validatorType = validatorType; // Hata vermezse validatorType gönderilen validatorType'tir.
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //validator'ın instance'sını oluştur.(newlw)
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //validatorType'in base tipini bul ve onun çalıştığı generic çalıştığı veri tipini bul.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //Generic veri tipine eşt olan tüm parametrelerini bul.
            foreach (var entity in entities) // Hepsi için validatorı çalıştır.
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
