﻿using doLittle.Extensions;
using Machine.Specifications;

namespace doLittle.Specs.Extensions.for_TypeExtensions
{
    public class when_asking_a_type_with_a_default_constructor_if_it_has_a_non_default_constructor
    {
        static bool result;

        Because of = () => result = typeof(TypeWithDefaultConstructor).HasNonDefaultConstructor();

        It should_return_false = () => result.ShouldBeFalse();
    }
}
