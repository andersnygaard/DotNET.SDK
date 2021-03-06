﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace doLittle.Events.Azure.Tables
{
    /// <summary>
    /// Delegate for providing connection string for <see cref="EventStore"/>
    /// </summary>
    /// <returns></returns>
    public delegate string ICanProvideConnectionString();
}
