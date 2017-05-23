﻿using System;
using Bifrost.Commands;
using Bifrost.Execution;
using Bifrost.FluentValidation.Commands;
using Machine.Specifications;
using Moq;

namespace Bifrost.FluentValidation.Specs.Commands.for_CommandValidatorProvider.given
{
    public class a_command_validator_provider_with_input_and_business_validators : commands
    {
        protected static CommandValidatorProvider command_validator_provider;

        protected static Mock<IContainer> container_mock;
        protected static Mock<ITypeDiscoverer> type_discoverer_mock;


        protected static Type[] command_input_validators = new[] {
                                                               typeof(SimpleCommandInputValidator),
                                                               typeof(AnotherSimpleCommandInputValidator)
                                                         };
        protected static Type[] command_business_validators = new[] {
                                                                typeof(SimpleCommandBusinessValidator),
                                                                typeof(AnotherSimpleCommandBusinessValidator)
                                                            };

        protected static Type[] input_validators = new[] {
                                                               typeof(LongConceptInputValidator),
                                                               typeof(StringConceptInputValidator)
                                                         };
        protected static Type[] business_validators = new[] {
                                                                typeof(LongConceptBusinessValidator),
                                                                typeof(StringConceptBusinessValidator)
                                                            };

        protected static BindingLifecycle lifecycle;

        Establish context = () =>
                                {
                                    container_mock = new Mock<IContainer>();
                                    type_discoverer_mock = new Mock<ITypeDiscoverer>();

                                    type_discoverer_mock.Setup(td => td.FindMultiple(typeof (ICommandInputValidator)))
                                        .Returns(new []
                                                {
                                                    typeof(SimpleCommandInputValidator),
                                                    typeof(AnotherSimpleCommandInputValidator),
                                                    typeof(NullCommandInputValidator<ICommand>)
                                                }
                                        );

                                    type_discoverer_mock.Setup(td => td.FindMultiple(typeof (ICommandBusinessValidator)))
                                        .Returns(new []
                                                {
                                                    typeof(SimpleCommandBusinessValidator),
                                                    typeof(AnotherSimpleCommandBusinessValidator),
                                                    typeof(NullCommandBusinessValidator<ICommand>)
                                                }
                                        );

                                    type_discoverer_mock.Setup(td => td.FindMultiple(typeof(ICommandInputValidator)))
                                        .Returns(new[]
                                                {
                                                    typeof(SimpleCommandInputValidator),
                                                    typeof(AnotherSimpleCommandInputValidator),
                                                    typeof(NullCommandInputValidator<ICommand>)
                                                }
                                        );

                                    type_discoverer_mock.Setup(td => td.FindMultiple(typeof(ICommandBusinessValidator)))
                                        .Returns(new[]
                                                {
                                                    typeof(SimpleCommandBusinessValidator),
                                                    typeof(AnotherSimpleCommandBusinessValidator),
                                                    typeof(NullCommandBusinessValidator<ICommand>)
                                                }
                                        );


                                    command_validator_provider = new CommandValidatorProvider(
                                        type_discoverer_mock.Object,
                                        container_mock.Object);
                                };
    }
}