using System;
using Jal.Factory.Fluent.Interface;
using Jal.Factory.Impl;
using Jal.Factory.Tests.Impl;
using Jal.Factory.Tests.Interfaces;
using Jal.Locator.Interface;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Jal.Factory.Tests
{
    [TestFixture]
    public class ObjectCreatorTests
    {
        [Test]
        public void Create_WithNotNullType_ShouldBeNotNull()
        {
            var locator = new Mock<IServiceLocator>();

            locator.Setup(x => x.Resolve<IDoSomething>(It.IsAny<string>())).Returns(new DoSomething());

            var sut = new ObjectCreator(locator.Object);

            var instance = sut.Create<IDoSomething>(typeof(DoSomething));

            instance.ShouldNotBeNull();

            instance.ShouldBeOfType<DoSomething>();

            instance.ShouldBeAssignableTo<IDoSomething>();
        }

        [Test]
        public void Create_WithNullType_ShouldBeNotNull()
        {
            var locator = new Mock<IServiceLocator>();

            locator.Setup(x => x.Resolve<IDoSomething>(It.IsAny<string>())).Returns(new DoSomething());

            var sut = new ObjectCreator(locator.Object);

            Should.Throw<Exception>(()=>sut.Create<IDoSomething>(null));
        }
    }
}