﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using doLittle.Execution;

namespace doLittle.Web.Commands
{
    [Singleton]
    public class CommandContextConnectionManager : ICommandContextConnectionManager
    {
        Dictionary<Guid, string> connectionIdsByCommandContext = new Dictionary<Guid, string>();
        Dictionary<string, List<Guid>> commandContextsByConnectionId = new Dictionary<string, List<Guid>>();

        public void Register(string connectionId, Guid commandContext)
        {
            connectionIdsByCommandContext[commandContext] = connectionId;
            var commandContexts = GetOrCreateListOfCommandContextsForConnectionId(connectionId);

            if( !commandContexts.Contains(commandContext) )
                commandContexts.Add(commandContext);
        }

        public bool HasConnectionForCommandContext(Guid commandContext)
        {
            return connectionIdsByCommandContext.ContainsKey(commandContext);
        }

        public void RemoveConnectionIfPresent(string connectionId)
        {
            var commandContexts = commandContextsByConnectionId[connectionId];
            foreach (var commandContext in commandContexts)
                connectionIdsByCommandContext.Remove(commandContext);

            commandContextsByConnectionId.Remove(connectionId);
        }

        public string GetConnectionForCommandContext(Guid commandContext)
        {
            ThrowIfUnknownCommandContext(commandContext);
            
            return connectionIdsByCommandContext[commandContext];
        }

        List<Guid> GetOrCreateListOfCommandContextsForConnectionId(string connectionId)
        {
            List<Guid> commandContexts;
            if (!commandContextsByConnectionId.ContainsKey(connectionId))
            {
                commandContexts = new List<Guid>();
                commandContextsByConnectionId[connectionId] = commandContexts;
            }
            else
                commandContexts = commandContextsByConnectionId[connectionId];
            return commandContexts;
        }

        void ThrowIfUnknownCommandContext(Guid commandContext)
        {
            if (!connectionIdsByCommandContext.ContainsKey(commandContext))
                throw new UnknownCommandContextException();
        }

    }
}
