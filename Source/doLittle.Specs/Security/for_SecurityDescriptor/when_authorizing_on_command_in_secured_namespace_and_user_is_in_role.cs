﻿using System.Security.Principal;
using doLittle.Security;
using doLittle.Specs.Security.Fakes;
using Machine.Specifications;

namespace doLittle.Specs.Security.for_SecurityDescriptor
{
    [Subject(typeof(BaseSecurityDescriptor))]
    public class when_authorizing_on_command_in_secured_namespace_and_user_is_in_role : given.a_configured_security_descriptor
    {
        static AuthorizeDescriptorResult authorize_descriptor_result;

        Establish context = () =>
        {
            resolve_principal_mock.Setup(m => m.Resolve()).Returns(
                new GenericPrincipal(
                    new GenericIdentity(""),
                    new[] { SecurityDescriptor.NAMESPACE_ROLE }));
        };

        Because of = () =>
            authorize_descriptor_result = security_descriptor.Authorize(command_that_has_namespace_rule);

        It should_be_authorized = () => authorize_descriptor_result.IsAuthorized.ShouldBeTrue();
    }
}
