﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2008-2017 doLittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace doLittle.CodeGeneration.JavaScript
{
    /// <summary>
    /// Represents the abstract of a container like <see cref="FunctionBody"/> or <see cref="ObjectLiteral"/>
    /// </summary>
    public abstract class Container : LanguageElement
    {
#pragma warning disable 1591
        public override abstract void Write(ICodeWriter writer);
#pragma warning restore 1591
    }
}
