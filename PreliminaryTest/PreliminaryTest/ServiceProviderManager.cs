using Microsoft.Extensions.DependencyInjection;
using PreliminaryTest.Service;
using PreliminaryTest.Service.Interface;
using System;

namespace PreliminaryTest
{
    static class ServiceProviderManager
    {
        private static IServiceProvider _serviceProvider;

        public static void RegisterServices()
        {
            var collection = new ServiceCollection();

            collection.AddScoped<IStringHelperService, StringHelperService>();
            collection.AddScoped<IStringProcessorService, StringProcessorService>();

            _serviceProvider = collection.BuildServiceProvider();
        }

        public static T GetService<T>() where T : class
        {
            return _serviceProvider.GetService<T>();
        }

        public static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
