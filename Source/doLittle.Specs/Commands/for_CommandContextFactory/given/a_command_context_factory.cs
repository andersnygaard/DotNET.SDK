﻿using doLittle.Commands;
using doLittle.Events;
using Machine.Specifications;
using Moq;
using doLittle.Execution;
using doLittle.Logging;

namespace doLittle.Specs.Commands.for_CommandContextFactory.given
{
    public class a_command_context_factory
    {
        protected static CommandContextFactory factory;
        protected static Mock<IUncommittedEventStreamCoordinator> uncommitted_event_stream_coordinator;
        protected static Mock<IProcessMethodInvoker> process_method_invoker_mock;
        protected static Mock<IExecutionContextManager> execution_context_manager_mock;
        protected static Mock<ILogger> logger;

        Establish context = () =>
                                {
                                    uncommitted_event_stream_coordinator = new Mock<IUncommittedEventStreamCoordinator>();
                                    process_method_invoker_mock = new Mock<IProcessMethodInvoker>();
                                    execution_context_manager_mock = new Mock<IExecutionContextManager>();
                                    logger = new Mock<ILogger>();
                                           
                                    factory = new CommandContextFactory(
                                        uncommitted_event_stream_coordinator.Object, 
                                        process_method_invoker_mock.Object,
                                        execution_context_manager_mock.Object,
                                        logger.Object);
                                };
    }
}
