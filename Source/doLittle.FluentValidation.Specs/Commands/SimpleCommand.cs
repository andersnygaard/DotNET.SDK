﻿using System;
using doLittle.Commands;

namespace doLittle.FluentValidation.Specs.Commands
{
    public class SimpleCommand : ICommand
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string SomeString { get; set; }

        public int SomeInt { get; set; }
    }
}
