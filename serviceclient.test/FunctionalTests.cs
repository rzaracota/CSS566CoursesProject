using serviceclient.types;
using System;
using Xunit;

namespace serviceclient.test
{
    public class Modules
    {
        private static string endpoint = "http://localhost:1738/module";

        private static ServiceClient<Module> client = new ServiceClient<Module>(endpoint);

        [Fact]
        public void GetReturnsAListOfModules()
        {
            var modules = client.Get();

            Assert.NotEmpty(modules);
        }

        [Fact]
        public void GetReturnsModulesWithNames()
        {
            var modules = client.Get();

            Assert.NotEmpty(modules);

            Assert.NotNull(modules[0].Author);
        }

        [Fact]
        public void GetReturnsModulesWithTitles()
        {
            var modules = client.Get();

            Assert.NotEmpty(modules);

            Assert.NotNull(modules[0].Title);
        }
    }
}
