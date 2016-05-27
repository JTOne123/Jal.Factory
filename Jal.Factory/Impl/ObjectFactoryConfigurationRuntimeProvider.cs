﻿using System;
using Jal.Factory.Interface;
using Jal.Factory.Model;

namespace Jal.Factory.Impl
{
    public class ObjectFactoryConfigurationRuntimeProvider : IObjectFactoryConfigurationRuntimeProvider
    {
        public bool Provide<TTarget, TResult>(ObjectFactoryConfigurationItem configurationItem, TTarget instance, TResult result)
        {
            if (configurationItem.Filter != null)
            {
                var filter = configurationItem.Filter as Func<TTarget, TResult, bool>;

                if (filter != null)
                {
                    return filter(instance, result);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}