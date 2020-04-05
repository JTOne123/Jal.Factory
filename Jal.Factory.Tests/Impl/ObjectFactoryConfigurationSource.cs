﻿using Jal.Factory.Tests.Interfaces;
using Jal.Factory.Tests.Model;

namespace Jal.Factory.Tests.Impl
{
    public class ObjectFactoryConfigurationSource : AbstractObjectFactoryConfigurationSource
    {
        public ObjectFactoryConfigurationSource()
        {
            
        }
    }

    public class AutoObjectFactoryConfigurationSource : AbstractObjectFactoryConfigurationSource
    {
        public AutoObjectFactoryConfigurationSource()
        {
            For<Customer, IDoSomething>().Create<DoSomething>().When(x => x.Age > 18);
            For<Customer, IDoSomething>().Create<DoSomething2>().When(x => x.Age < 18);
        }
    }
}
