﻿using System;
using doLittle.Concepts;
using Machine.Specifications;

namespace doLittle.Specs.Concepts.for_ConceptExtensions
{
    [Subject(typeof (ConceptExtensions))]
    public class when_checking_is_concept_on_a_concept : given.concepts
    {
        static bool is_a_concept;

        Because of = () => is_a_concept = value_as_a_long.GetType().IsConcept();

        It should_be_a_concept = () => is_a_concept.ShouldBeTrue();
    }
}