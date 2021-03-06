﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using doLittle.Conventions;

namespace doLittle.Commands
{
    /// <summary>
    /// Defines the basic command.
    /// </summary>
    /// <remarks>Implementing classes must have a default constructor.</remarks>
    /// <remarks>
    /// Types inheriting from this interface will be picked up proxy generation, deserialized and dispatched to the
    /// correct instance of <see cref="IHandleCommands"/>.
    /// You most likely want to subclass <see cref="Command"/>.
    /// </remarks>
    public interface ICommand : IConvention
    {
    }
}
