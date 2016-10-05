using Jal.Factory.Interface;

namespace Jal.Factory.Fluent.Interface
{
    public interface IObjectFactoryProviderFluentBuilder
    {
        IObjectFactoryFluentBuilder UseConfigurationSource(IObjectFactoryConfigurationSource[] objectFactoryConfigurationSources);
    }
}