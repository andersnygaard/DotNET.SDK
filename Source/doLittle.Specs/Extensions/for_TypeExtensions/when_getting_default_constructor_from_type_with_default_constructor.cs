﻿using System.Reflection;
using doLittle.Extensions;
using Machine.Specifications;

namespace doLittle.Specs.Extensions.for_TypeExtensions
{
    public class when_getting_default_constructor_from_type_with_default_constructor
    {
        static ConstructorInfo  constructor_info;

        Because of = () => constructor_info = typeof(TypeWithDefaultConstructor).GetDefaultConstructor();

        It should_return_a_constructor = () => constructor_info.ShouldNotBeNull();
    }
}
