using System.ComponentModel.DataAnnotations;

namespace GameStore.API.CustomeFilters;

public class ValidationFilter<T> : IEndpointFilter where T : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var dto = context.Arguments.OfType<T>().FirstOrDefault();
        if (dto is null) return Results.BadRequest("Invalid request body.");

        var validationContext = new ValidationContext(dto);
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(dto, validationContext, results, true);

        if (!isValid)
        {
            return Results.ValidationProblem(results.ToDictionary(
                r => r.MemberNames.FirstOrDefault() ?? "",
                r => new[] { r.ErrorMessage ?? "Invalid" }
            ));
        }

        return await next(context);
    }
}
