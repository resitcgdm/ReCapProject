using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect:Metodu başında ,sonunda,hata verdiğinde calısacak yapı.
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) //method interception da virtual olan before metodunu eziyoruz...
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection:Çalışma anında bişeyler yapılmasını sağlar.ProductValidatoru verir.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //carvalidatorun çalışma tipini bul ve generic elemanlarından ilkini getir.Product tipini verir.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //invocation metot demek yani metodun parametrelerini bul diyor
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
