﻿using Bifrost.Events;

namespace Bifrost.Specs.Events.Fakes.v3
{
    public class SimpleEvent : v2.SimpleEvent, IAmNextGenerationOf<v2.SimpleEvent>
    {
        public static string DEFAULT_VALUE_FOR_THIRD_GENERATION_PROPERTY = "3rd: DEFAULT";

        public string ThirdGenerationProperty { get; set; }

        public SimpleEvent(EventSourceId eventSourceId) : base(eventSourceId)
        {
            ThirdGenerationProperty = DEFAULT_VALUE_FOR_THIRD_GENERATION_PROPERTY;
        }
    }
}