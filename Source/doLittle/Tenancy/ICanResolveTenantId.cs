﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace doLittle.Tenancy
{
    /// <summary>
    /// Defines systems that can resolve the <see cref="TenantId"/> of a <see cref="ITenant"/>
    /// </summary>
    public interface ICanResolveTenantId
    {
        /// <summary>
        /// Resolves the <see cref="TenantId"/>
        /// </summary>
        /// <returns><see cref="TenantId"/> of the current <see cref="ITenant"/></returns>
        TenantId Resolve();
    }
}
