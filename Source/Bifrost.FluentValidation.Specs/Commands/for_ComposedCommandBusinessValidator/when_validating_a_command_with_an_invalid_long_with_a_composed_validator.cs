using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bifrost.FluentValidation.Commands;
using Machine.Specifications;

namespace Bifrost.FluentValidation.Specs.Commands.for_ComposedCommandBusinessValidator
{
    [Subject(typeof(ComposedCommandBusinessValidator<>))]
    public class when_validating_a_command_with_an_invalid_long_with_a_composed_validator : given.a_composed_command_business_validator
    {
        static IEnumerable<ValidationResult> result;

        Because of = () => result = composed_validator.ValidateFor(command_with_invalid_long);

        It should_not_be_valid = () => result.ShouldNotBeEmpty();
    }
}