﻿using doLittle.FluentValidation.MetaData;
using doLittle.Validation.MetaData;
using FluentValidation.Validators;
using Machine.Specifications;

namespace doLittle.FluentValidation.Specs.MetaData.for_RequiredGenerator
{
    public class when_generating_from_not_empty
    {
        static NotEmptyValidator validator;
        static RequiredGenerator generator;
        static Required result;

        Establish context = () =>
        {
            validator = new NotEmptyValidator("");
            generator = new RequiredGenerator();
        };

        Because of = () => result = generator.GeneratorFrom("someProperty",validator) as Required;

        It should_create_a_rule = () => result.ShouldNotBeNull();
    }
}
