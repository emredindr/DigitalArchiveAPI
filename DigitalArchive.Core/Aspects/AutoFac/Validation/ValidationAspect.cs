using Castle.DynamicProxy;
using DigitalArchive.Core.Extensions.ResponseAndExceptionMiddleware;
using DigitalArchive.Core.Utilities.Interceptors;
using DigitalArchive.Core.Validation.FluentValidation;
using FluentValidation;

namespace DigitalArchive.Core.Aspects.AutoFac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new ApiException("AspectMessages.WrongValidationType");

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities) ValidationTool.Validate(validator, entity);
        }
    }
}
