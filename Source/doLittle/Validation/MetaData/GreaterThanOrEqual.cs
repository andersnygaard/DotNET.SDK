﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace doLittle.Validation.MetaData
{
    /// <summary>
    /// Represents the metadata for the GreaterThanOrEqual validation rule
    /// </summary>
    public class GreaterThanOrEqual : Rule
    {
        /// <summary>
        /// Gets or sets the value that values validated up against must be greater than
        /// </summary>
        public object Value { get; set; }
    }
}
