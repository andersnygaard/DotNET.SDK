﻿using System;
using System.Reflection;
using doLittle.Reflection;
using Machine.Specifications;

namespace doLittle.Specs.Reflection.for_Proxying
{
    [Ignore("Work in progress")]
    public class when_building_class_with_properties_from_other_type
    {
        static Proxying proxying;
        static Type result; 

        Establish context = () => proxying = new Proxying();

        Because of = () => result = proxying.BuildClassWithPropertiesFrom(typeof(TypeWithProperties));

        It should_not_be_an_interface = () => result.GetTypeInfo().IsInterface.ShouldBeFalse();
        It should_hold_integer_property = () => result.GetTypeInfo().GetProperty("Integer").ShouldNotBeNull();
        It should_hold_string_property = () => result.GetTypeInfo().GetProperty("String").ShouldNotBeNull();
    }
}