namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios.Filetype;

using BusinessLogic.Contracts;
using FluentValidation;

public class GetFiletypeByIdInputScenarioValidator : AbstractValidator<FiletypeInput>
{
    public GetFiletypeByIdInputScenarioValidator()
    {
        RuleFor(r => r.Id)
            .GreaterThanOrEqualTo(1)
            .WithMessage($"The id of {nameof(FiletypeInput)} entity must be greater or equals to 1.");
    }
}