using FluentValidation;

public class CustomerValidator : AbstractValidator<Test>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Name).NotNull();
    }
}
public class Test
{
    public string Name { get; set; } = default!;
}