﻿using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace doLittle.Specs.Execution.for_ContractToImplementorsMap
{
    public class when_getting_implementors_of_interface_that_has_one_implementation : given.an_empty_map
    {
        static IEnumerable<Type> result;

        Establish context = () => map.Feed(new[] { typeof(ImplementationOfInterface) });

        Because of = () => result = map.GetImplementorsFor(typeof(IInterface));

        It should_have_the_implementation_only = () => result.ShouldContainOnly(typeof(ImplementationOfInterface));
    }
}
