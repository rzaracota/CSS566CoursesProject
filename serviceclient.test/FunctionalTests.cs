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

        [Fact]
        public void GetIdReturnsValidModule()
        {
            var modules = client.Get();

            Assert.NotEmpty(modules);

            var author = modules[0].Author;

            var title = modules[0].Title;

            var module = client.Get(modules[0].ModuleId);

            Assert.NotNull(module);

            Assert.Equal(author, module.Author);
            Assert.Equal(title, module.Title);
        }

        [Fact]
        public void SubmoduleInfoIsPopulatedCorrectly()
        {
            var modules = client.Get();

            Assert.NotEmpty(modules);

            var module = modules[0];

            Assert.NotNull(module.CourseModule);

            Assert.True(module.CourseModule.ModuleId >= 0);
            Assert.True(module.CourseModule.CourseId >= 0);
        }
    }
}
