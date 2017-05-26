﻿using Bifrost.Events;
using Machine.Specifications;

namespace Bifrost.Specs.Events.for_EventSource
{
    [Subject(typeof (EventSource))]
    public class when_fast_fowarding_a_stateful_aggregate_root : given.a_stateful_event_source
    {
        static InvalidFastForwardException exception;
        static EventSourceVersion last_commit;

        Establish context = () => last_commit = new EventSourceVersion(1,1);

        Because of = () => exception = Catch.Exception(() => event_source.FastForward(last_commit)) as InvalidFastForwardException;

        It should_throw_an_invalid_fast_forward_exception = () => exception.ShouldNotBeNull();
    }
}