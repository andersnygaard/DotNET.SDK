﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Events;
using doLittle.Execution;
using doLittle.Logging;

namespace doLittle.Commands
{
    /// <summary>
    /// Represents a <see cref="ICommandContextFactory"/>
    /// </summary>
    public class CommandContextFactory : ICommandContextFactory
    {
        readonly IUncommittedEventStreamCoordinator _uncommittedEventStreamCoordinator;
        readonly IProcessMethodInvoker _processMethodInvoker;
        readonly IExecutionContextManager _executionContextManager;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="CommandContextFactory">CommandContextFactory</see>
        /// </summary>
        /// <param name="uncommittedEventStreamCoordinator">A <see cref="IUncommittedEventStreamCoordinator"/> to use for coordinator an <see cref="UncommittedEventStream"/></param>
        /// <param name="processMethodInvoker">A <see cref="IProcessMethodInvoker"/> for processing events</param>
        /// <param name="executionContextManager">A <see cref="IExecutionContextManager"/> for getting execution context from</param>
        /// <param name="logger"><see cref="ILogger"/> to use for logging</param>
        public CommandContextFactory(
            IUncommittedEventStreamCoordinator uncommittedEventStreamCoordinator,
            IProcessMethodInvoker processMethodInvoker,
            IExecutionContextManager executionContextManager,
            ILogger logger)
        {
            _uncommittedEventStreamCoordinator = uncommittedEventStreamCoordinator;
            _processMethodInvoker = processMethodInvoker;
            _executionContextManager = executionContextManager;
            _logger = logger;
        }

        /// <inheritdoc/>
        public ICommandContext Build(CommandRequest command)
        {
            return new CommandContext(
                command,
                _executionContextManager.Current,
                _uncommittedEventStreamCoordinator,
                _logger
                );
        }
    }
}