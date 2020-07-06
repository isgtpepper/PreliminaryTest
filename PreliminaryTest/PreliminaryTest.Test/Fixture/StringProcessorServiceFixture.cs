using PreliminaryTest.Service;
using PreliminaryTest.Service.Interface;
using System;

namespace PreliminaryTest.Test.Fixture
{
    public class StringProcessorServiceFixture : IDisposable
    {
        public IStringProcessorService StringProcessorService { get; private set; }

        public StringProcessorServiceFixture() {

            ServiceProviderManager.RegisterServices();
            StringProcessorService = ServiceProviderManager.GetService<IStringProcessorService>();
        }

        public void Dispose()
        {
            ServiceProviderManager.DisposeServices();
        }
    }
}
