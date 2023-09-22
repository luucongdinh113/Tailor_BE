using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Tailor_Business.Commons
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);
            var errors = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .Distinct()
                .ToArray();
                //.GroupBy(
                //    x => x.PropertyName,
                //    x => x.ErrorMessage,
                //    (propertyName, errorMessages) => new
                //    {
                //        Key = propertyName,
                //        Values = errorMessages.Distinct().ToArray()
                //    })
                //.ToDictionary(x => x.Key, x => x.Values);
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
            return await next();
        }
    }
}
