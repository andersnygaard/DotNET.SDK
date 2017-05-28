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
    public class when_generating__datetime_nullables__
    {
        static Container container;
        static Mock<ICodeWriter> writer_mock;

        Establish context = () =>
            {
                container = new FunctionBody();
                writer_mock = new Mock<ICodeWriter>();
            };

        Because of = () => container.WithPropertiesFrom(typeof(ObjectWithDateTimeNullable)).Write(writer_mock.Object);

        It should_write_property_name = () => writer_mock.Verify(w => w.WriteWithIndentation("this.{0} = ", "dateTimeNullableProperty"));
        It should_write__property_value = () => writer_mock.Verify(w => w.Write("null", Moq.It.IsAny<Object[]>()));

    }
    
}
