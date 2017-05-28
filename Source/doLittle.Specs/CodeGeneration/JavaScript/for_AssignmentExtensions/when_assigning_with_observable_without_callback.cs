﻿using Machine.Specifications;
using doLittle.CodeGeneration.JavaScript;

namespace doLittle.Specs.CodeGeneration.JavaScript.for_AssignmentExtensions
{
    public class when_assigning_with_observable_without_callback : given.an_assignment
    {
        Because of = () => assignment.WithObservable();

        It should_set_value_to_be_an_observable = () => assignment.Value.ShouldBeOfExactType<Observable>();
    }
}
