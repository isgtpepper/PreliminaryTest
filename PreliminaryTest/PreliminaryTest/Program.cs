using PreliminaryTest.Service;
using PreliminaryTest.Service.Interface;
using System;
using System.Linq;

namespace PreliminaryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProviderManager.RegisterServices();

            try
            {
                var stringProcessorService = ServiceProviderManager.GetService<IStringProcessorService>();
                var testResults = stringProcessorService.ProcessStrings("AAAc91%cWwWkLq$1ci3_848v3d__K");

                testResults.ToList().ForEach(result => Console.WriteLine($"Result is: {result}"));
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception is: {ex}");
                Console.ReadLine();

                throw;
            }
            finally
            {
                ServiceProviderManager.DisposeServices();
            }
        }
    }
}
