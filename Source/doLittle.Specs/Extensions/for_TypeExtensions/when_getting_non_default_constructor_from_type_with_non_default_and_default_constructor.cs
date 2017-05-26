﻿using System.Reflection;
using Bifrost.Extensions;
using Machine.Specifications;

namespace Bifrost.Specs.Extensions.for_TypeExtensions
{
    public class when_getting_default_constructor_from_type_with_non_default_and_default_constructor
    {
        static ConstructorInfo  constructor_info;

        Because of = () => constructor_info = typeof(TypeWithDefaultAndNonDefaultConstructor).GetDefaultConstructor();

        It should_return_a_constructor = () => constructor_info.ShouldNotBeNull();
        It should_return_correct_constructor = () => constructor_info.GetParameters().Length.ShouldEqual(0);
    }
}
