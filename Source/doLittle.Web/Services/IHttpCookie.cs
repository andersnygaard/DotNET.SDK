/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace doLittle.Web.Services
{
    /// <summary>
    /// Defines a HTTP cookie
    /// </summary>
    public interface IHttpCookie
    {
        /// <summary>
        /// Gets the name of the <see cref="IHttpCookie"/>
        /// </summary>
        /// <returns>The <see cref="string"/> representing the name</returns>
        string Name { get; }

        /// <summary>
        /// Gets the value for the <see cref="IHttpCookie"/>
        /// </summary>
        /// <returns>The <see cref="string"/> value</returns>
        string Value { get; }
    }
}