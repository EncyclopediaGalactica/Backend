namespace DocumentDomain.Spec.Operations.Scenario.Relation;

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using EncyclopediaGalactica.DocumentDomain.Operations.Scenarios.Relation;
using FluentAssertions;
using FluentValidation.Results;

public class EditRelationScenarioInputValidatorShould
{
    private EditRelationScenarioInputValidator _validator = new();

    [Theory]
    [ClassData(typeof(EditRelationScenarioInputValidatorInvalidData))]
    public void ReturnInvalid_WhenInputIsInvalid(RelationInput input)
    {
        ValidationResult? result = _validator.Validate(input);
        result.IsValid.Should().BeFalse();
        result.Errors.Count.Should().BeGreaterOrEqualTo(1);
    }

    [Theory]
    [ClassData(typeof(EditRelationScenarioInputValidatorValidData))]
    public void ReturnValid_WhenInputIsInvalid(RelationInput input)
    {
        ValidationResult? result = _validator.Validate(input);
        result.IsValid.Should().BeTrue();
    }
}

[ExcludeFromCodeCoverage]
public class EditRelationScenarioInputValidatorInvalidData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new RelationInput
            {
                Id = 0,
                LeftEndId = 1,
                RightEndId = 1,
            },
        };
        yield return new object[]
        {
            new RelationInput
            {
                Id = 1,
                LeftEndId = 0,
                RightEndId = 1,
            },
        };
        yield return new object[]
        {
            new RelationInput
            {
                Id = 1,
                LeftEndId = 1,
                RightEndId = 0,
            },
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

[ExcludeFromCodeCoverage]
public class EditRelationScenarioInputValidatorValidData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new RelationInput
            {
                Id = 1,
                LeftEndId = 1,
                RightEndId = 1,
            },
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

