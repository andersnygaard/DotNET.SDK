﻿using doLittle.Execution;
using doLittle.Types;
using Machine.Specifications;
using Moq;

namespace doLittle.Specs.Read.Validation.for_QueryValidationDescriptors.given
{
    public class all_dependencies
    {
        protected static Mock<ITypeDiscoverer> type_discoverer_mock;
        protected static Mock<IContainer> container_mock;

        Establish context = () =>
        {
            type_discoverer_mock = new Mock<ITypeDiscoverer>();
            container_mock = new Mock<IContainer>();
        };
    }
}
