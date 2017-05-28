﻿using System;
using Machine.Specifications;
using It = Machine.Specifications.It;

namespace doLittle.Web.Specs.Services.for_RestServiceMethodInvoker
{
    public class when_invoking_with_a_guid_concept_as_escaped_string_as_a_parameter : given.a_rest_service_method_invoker_and_a_service_call_for_guid_input_and_no_output
    {
        static GuidConcept expected_guid_concept = new GuidConcept { Value = Guid.NewGuid() };

        Establish context = () =>
            {
                parameters.Add("input", "\"" + expected_guid_concept.ToString() + "\"");
            };

        Because of = () => invoker.Invoke(base_url, service_instance, uri, parameters);

        It should_invoke_the_method_on_the_service_instance = () => service_instance.GuidInputNoOutputCalled.ShouldBeTrue();
        It should_pass_the_correct_parameter = () => service_instance.GuidInputNoOutputInput.ShouldEqual(expected_guid_concept);
    }
}
