using System;
using Jal.Factory.Fluent.Interface;
using Jal.Factory.Impl;
using Jal.Factory.Interface;
using Jal.Locator.Interface;

namespace Jal.Factory.Fluent.Impl
{
    public class ObjectFactoryFluentBuilder : IObjectFactoryStartFluentBuilder, IObjectFactoryFluentBuilder, IObjectFactoryProviderFluentBuilder
    {
        public IObjectCreator ObjectCreator;

        public IObjectFactoryInterceptor ObjectFactoryInterceptor;

        public IObjectFactoryConfigurationProvider ObjectFactoryConfigurationProvider;

        public IObjectFactoryProviderFluentBuilder UseLocator(IServiceLocator serviceLocator)
        {
            if (serviceLocator == null)
            {
                throw new ArgumentNullException(nameof(serviceLocator));
            }

            ObjectCreator = new ObjectCreator(serviceLocator);

            return this;
        }

        public IObjectFactoryFluentBuilder UseConfigurationSource(IObjectFactoryConfigurationSource[] objectFactoryConfigurationSources)
        {
            if (objectFactoryConfigurationSources == null)
            {
                throw new ArgumentNullException(nameof(objectFactoryConfigurationSources));
            }

            ObjectFactoryConfigurationProvider = new ObjectFactoryConfigurationProvider(objectFactoryConfigurationSources);

            return this;
        }

        public IObjectFactoryFluentBuilder UseInterceptor(IObjectFactoryInterceptor objectFactoryInterceptor)
        {
            if (objectFactoryInterceptor == null)
            {
                throw new ArgumentNullException(nameof(objectFactoryInterceptor));
            }

            ObjectFactoryInterceptor = objectFactoryInterceptor;

            return this;
        }

        public IObjectFactory Create
        {
            get
            {          
                if (ObjectFactoryConfigurationProvider == null || ObjectCreator == null)
                {
                    throw new Exception("An implementation of IObjectFactoryConfigurationProvider/IObjectCreator is needed");
                }

                var result = new ObjectFactory(ObjectFactoryConfigurationProvider, ObjectCreator);

                if (ObjectFactoryInterceptor != null)
                {
                    result.Interceptor = ObjectFactoryInterceptor;
                }

                return result;
            }
        }
    }
}