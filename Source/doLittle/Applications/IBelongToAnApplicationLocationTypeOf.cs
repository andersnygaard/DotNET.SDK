﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace doLittle.Applications
{
    /// <summary>
    /// Defines a parent relationship to another <see cref="IApplicationLocation"/> of a specific
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBelongToAnApplicationLocationTypeOf<T>
        where T : IApplicationLocation
    {
        /// <summary>
        /// Gets the parent <see cref="IApplicationLocation">location</see>
        /// </summary>
        T Parent { get; }
    }
}