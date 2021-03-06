﻿using System;
using doLittle.Read;
using doLittle.Security;
using Machine.Specifications;
using Moq;

namespace doLittle.Specs.Read.for_QueryCoordinator.given
{
    public class a_query_coordinator_with_known_provider : a_query_coordinator
    {
        protected static Mock<IQueryProviderFor<QueryType>> query_provider_mock;
        protected static Type provider_type;

        Establish context = () =>
        {
            query_provider_mock = new Mock<IQueryProviderFor<QueryType>>();
            provider_type = query_provider_mock.Object.GetType();

            type_finder.Setup(t => t.FindMultiple(typeof(IQueryProviderFor<>))).Returns(new[] { provider_type });
            container.Setup(c => c.Get(provider_type)).Returns(query_provider_mock.Object);

            fetching_security_manager.Setup(f => f.Authorize(Moq.It.IsAny<IQuery>())).Returns(new AuthorizationResult());

            coordinator = new QueryCoordinator(
                type_finder.Object,
                container.Object,
                fetching_security_manager.Object,
                query_validator.Object,
                read_model_filters.Object,
                exception_publisher.Object);
        };
    }
}
