using System;
using Xunit;

namespace serviceclient.test
{
    public class Module
    {
        private static string endpoint = "http://localhost:1738/module";

        [Fact]
        public void GetReturnsAListOfModules()
        {
            var client = new ServiceClient<Module>(endpoint);

            var modules = client.Get();

            Assert.NotEmpty(modules);
        }
    }
}
