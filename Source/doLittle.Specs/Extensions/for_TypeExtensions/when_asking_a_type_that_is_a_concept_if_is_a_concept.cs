﻿using Machine.Specifications;
using doLittle.Concepts;
using doLittle.Extensions;

namespace doLittle.Specs.Extensions.for_TypeExtensions
{
    public class when_asking_a_type_that_is_a_concept_if_is_a_concept
    {
        static bool result;

        Because of = () => result = typeof(ConceptType).IsConcept();

        It should_return_true = () => result.ShouldBeTrue();
    }
}
