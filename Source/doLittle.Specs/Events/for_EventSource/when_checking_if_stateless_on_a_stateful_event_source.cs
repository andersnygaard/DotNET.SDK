﻿using doLittle.Events;
using Machine.Specifications;

namespace doLittle.Specs.Events.for_EventSource
{
    [Subject(typeof (EventSourceExtensions))]
    public class when_checking_if_stateless_on_a_stateful_event_source : given.a_stateful_event_source
    {
        static bool is_stateless;

        Because of = () => is_stateless = event_source.IsStateless();

        It should_not_be_stateless = () => is_stateless.ShouldBeFalse();
    }
}