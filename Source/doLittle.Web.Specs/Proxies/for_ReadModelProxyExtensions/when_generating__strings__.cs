﻿using doLittle.CodeGeneration;
using doLittle.CodeGeneration.JavaScript;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace doLittle.Web.Specs.Proxies.for_ReadModelProxyExtensions
{
    public class when_generating__strings__
    {
        static Container container;
        static Mock<ICodeWriter> writer_mock;

        Establish context = () =>
            {
                container = new FunctionBody();
                writer_mock = new Mock<ICodeWriter>();
            };

        Because of = () => container.WithPropertiesFrom(typeof(ObjectWithString)).Write(writer_mock.Object);

        It should_write_property_name = () => writer_mock.Verify(w => w.WriteWithIndentation("this.{0} = ", "stringProperty"));
        It should_write__property_value = () => writer_mock.Verify(w => w.Write("\"\"", Moq.It.IsAny<Object[]>()));

    }
    
}
