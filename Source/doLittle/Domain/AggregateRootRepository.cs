﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Reflection;
using doLittle.Applications;
using doLittle.Commands;
using doLittle.Events;
using doLittle.Logging;

namespace doLittle.Domain
{
    /// <summary>
    /// Defines a concrete implementation of <see cref="IAggregateRootRepository{T}">IAggregatedRootRepository</see>
    /// </summary>
    /// <typeparam name="T">Type the repository is for</typeparam>
    public class AggregateRootRepository<T> : IAggregateRootRepository<T>
        where T : AggregateRoot
    {
        ICommandContextManager _commandContextManager;
        IEventStore _eventStore;
        IEventSourceVersions _eventSourceVersions;
        IApplicationResources _applicationResources;
        readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="AggregateRootRepository{T}">AggregatedRootRepository</see>
        /// </summary>
        /// <param name="commandContextManager"> <see cref="ICommandContextManager"/> to use for tracking </param>
        /// <param name="eventStore"><see cref="IEventStore"/> for getting <see cref="IEvent">events</see></param>
        /// <param name="eventSourceVersions"><see cref="IEventSourceVersions"/> for working with versioning of <see cref="AggregateRoot"/></param>
        /// <param name="applicationResources"><see cref="IApplicationResources"/> for being able to identify resources</param>
        /// <param name="logger"><see cref="ILogger"/> to use for logging</param>
        public AggregateRootRepository(
            ICommandContextManager commandContextManager,
            IEventStore eventStore,
            IEventSourceVersions eventSourceVersions,
            IApplicationResources applicationResources, 
            ILogger logger)
        {
            _commandContextManager = commandContextManager;
            _eventStore = eventStore;
            _eventSourceVersions = eventSourceVersions;
            _applicationResources = applicationResources;
            _logger = logger;
        }

        /// <inheritdoc/>
		public T Get(EventSourceId id)
        {
            _logger.Trace($"Get '{typeof(T).AssemblyQualifiedName}' with Id of '{id?.Value.ToString() ?? "<unknown id>"}'");

            var commandContext = _commandContextManager.GetCurrent();
            var type = typeof(T);
            var constructor = GetConstructorFor(type);
            ThrowIfConstructorIsInvalid(type, constructor);

            var aggregateRoot = GetInstanceFrom(id, constructor);
            if (null != aggregateRoot)
            {
                if (!aggregateRoot.IsStateless())
                    ReApplyEvents(commandContext, aggregateRoot);
                else
                    FastForward(commandContext, aggregateRoot);
            }
            commandContext.RegisterForTracking(aggregateRoot);

            return aggregateRoot;
        }

        void FastForward(ICommandContext commandContext, T aggregateRoot)
        {
            _logger.Trace($"FastForward - {typeof(T).AssemblyQualifiedName}");
            var identifier = _applicationResources.Identify(typeof(T));
            _logger.Trace($"With identifier '{identifier?.ToString()??"<unknown identifier>"}'");
            
            var version = _eventSourceVersions.GetFor(identifier, aggregateRoot.EventSourceId);
            aggregateRoot.FastForward(version);
        }

        void ReApplyEvents(ICommandContext commandContext, T aggregateRoot)
        {
            var identifier = _applicationResources.Identify(typeof(T));
            var events = _eventStore.GetFor(identifier, aggregateRoot.EventSourceId);
            var stream = new CommittedEventStream(aggregateRoot.EventSourceId, events);
            if (stream.HasEvents)
                aggregateRoot.ReApply(stream);
        }

        T GetInstanceFrom(EventSourceId id, ConstructorInfo constructor)
        {
            return (constructor.GetParameters()[0].ParameterType == typeof(EventSourceId) ?
                constructor.Invoke(new object[] { id }) :
                constructor.Invoke(new object[] { id.Value })) as T;
        }

        ConstructorInfo GetConstructorFor(Type type)
        {
            return type.GetTypeInfo().GetConstructors().Where(c =>
            {
                var parameters = c.GetParameters();
                return parameters.Length == 1 &&
                    (parameters[0].ParameterType == typeof(Guid) ||
                    parameters[0].ParameterType == typeof(EventSourceId));
            }).SingleOrDefault();
        }

        void ThrowIfConstructorIsInvalid(Type type, ConstructorInfo constructor)
        {
            if (constructor == null) throw new InvalidAggregateRootConstructorSignature(type);
        }
    }
}