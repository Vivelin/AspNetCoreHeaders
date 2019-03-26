using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vivelin.AspNetCore.Headers.Tests
{
    [TestClass]
    public class ContentSecurityPolicyBuilderTests
    {
        [TestMethod]
        public void DefaultPropertiesAreIncludedInResultingDirectives()
        {
            var builder = new ContentSecurityPolicyBuilder();

            var directives = builder.Build();

            var directiveBuilders = builder.GetType()
                .GetProperties()
                .Where(x => typeof(ContentSecurityPolicyDirectiveBuilder).IsAssignableFrom(x.PropertyType));

            foreach (var item in directiveBuilders)
            {
                var directiveBuilder = (ContentSecurityPolicyDirectiveBuilder)item.GetValue(builder);
                var name = directiveBuilder.Build().Name;

                if (!directives.Any(x => x.Name == name))
                    throw new AssertFailedException($"The built CSP does not contain a '{name}' directive for property {item.Name}.");
            }
        }

        [TestMethod]
        public void PluginTypesDirectiveIsIncludedInTheResultingDirective()
        {
            var builder = new ContentSecurityPolicyBuilder();

            builder.PluginTypes.Add("application/pdf");

            var directives = builder.Build();
            var pluginTypeDirective = directives.Single(x => x.Name == "plugin-types").ToString();
            Assert.AreEqual("plugin-types application/pdf", pluginTypeDirective);
        }

        [TestMethod]
        public void CustomPropertiesAreIncludedInResultingDirectives()
        {
            const string directiveName = "x-test-directive";
            var builder = new ContentSecurityPolicyBuilder();

            builder.Add(directiveName, customDirective =>
            {
                customDirective.AllowFromSelf();
            });

            var directives = builder.Build();
            if (!directives.Any(x => x.Name == directiveName))
                throw new AssertFailedException("The build CSP does not contain a '" + directiveName + "' directive.");
        }
    }
}
