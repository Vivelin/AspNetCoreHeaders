using System;
using System.Collections.Generic;
using System.Linq;

namespace Vivelin.AspNetCore.Headers
{
    /// <summary>
    /// Provides an API for configuring a Content Security Policy.
    /// </summary>
    public class ContentSecurityPolicyBuilder
    {
        /// <summary>
        /// Restricts the URLs which can be used in a document's
        /// <c>&lt;base&gt;</c> element.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder BaseUri { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("base-uri");

        /// <summary>
        /// Retricts the URLs which can be loaded into frames (e.g.
        /// <c>&lt;iframe&gt;</c> and <c>&lt;frame&gt;</c>) or workers.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder ChildSrc { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("child-src");

        /// <summary>
        /// Restricts the URLs which can be loaded using script interfaces. This
        /// includes APIs like <c>fetch()</c>, XHR, <c>&lt;a&gt;</c>’s
        /// <c>ping</c> as well as WebSocket connections.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Fetch { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("connect-src");

        /// <summary>
        /// Controls requests for which no other directives are specified.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Default { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("default-src");

        /// <summary>
        /// Restricts the URLs from which font resources may be loaded.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Fonts { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("font-src");

        /// <summary>
        /// Restricts the URLs which can be used as the target of form
        /// submissions.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder FormAction { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("form-action");

        /// <summary>
        /// Restricts the URLs which can embed resources from this application.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder FrameAncestors { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("frame-ancestors");

        /// <summary>
        /// Restricts the URLs which may be loaded into frames.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Frames { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("frame-src");

        /// <summary>
        /// Restricts the URLs from which image resources may be loaded.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Images { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("img-src");

        /// <summary>
        /// Restricts the URLs from which application manifects may be loaded.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Manifests { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("manifest-src");

        /// <summary>
        /// Restricts the URLs from which video, audio and associated resources
        /// may be loaded.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Media { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("media-src");

        /// <summary>
        /// Restricts the URLs from which plugin content may be loaded.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Objects { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("object-src");

        /// <summary>
        /// Restricts the set of plugins that can be embedded into a document.
        /// </summary>
        public ContentSecurityPolicyMediaTypeDirectiveBuilder PluginTypes { get; }
            = new ContentSecurityPolicyMediaTypeDirectiveBuilder("plugin-types");

        /// <summary>
        /// Restricts the URLs from which resources me be prefetched or
        /// prerendered.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Prefetch { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("prefetch-src");

        /// <summary>
        /// Restricts the URLs from which scripts may be executed.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Scripts { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("script-src");

        /// <summary>
        /// Restricts the locations from which style may be applied to a
        /// document.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Styles { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("style-src");

        /// <summary>
        /// Restricts the URLs which may be loaded as a worker, shared worker or
        /// service worker.
        /// </summary>
        public ContentSecurityPolicySourceDirectiveBuilder Workers { get; }
            = new ContentSecurityPolicySourceDirectiveBuilder("worker-src");

        /// <summary>
        /// Gets a collection of custom directives.
        /// </summary>
        protected ICollection<ContentSecurityPolicyDirective> CustomDirectives { get; }
            = new List<ContentSecurityPolicyDirective>();

        /// <summary>
        /// Adds a custom Content Security Policy directive.
        /// </summary>
        /// <param name="directive">The name of the directive.</param>
        /// <param name="configure">
        /// An action used to specify the directive's values.
        /// </param>
        /// <returns>A reference to this builder.</returns>
        public ContentSecurityPolicyBuilder Add(string directive, Action<ContentSecurityPolicySourceDirectiveBuilder> configure)
        {
            var builder = new ContentSecurityPolicySourceDirectiveBuilder(directive);
            configure(builder);
            return Add(builder.Build());
        }

        /// <summary>
        /// Adds a custom Content Security Policy directive.
        /// </summary>
        /// <param name="directive">The configured directive.</param>
        /// <returns>A reference to this builder.</returns>
        public ContentSecurityPolicyBuilder Add(ContentSecurityPolicyDirective directive)
        {
            CustomDirectives.Add(directive);
            return this;
        }

        /// <summary>
        /// Returns a collection of the directives constructed by the <see
        /// cref="ContentSecurityPolicyBuilder"/>.
        /// </summary>
        /// <returns>
        /// An <see cref="ICollection{T}"/> of <see
        /// cref="ContentSecurityPolicyDirective"/> objects.
        /// </returns>
        protected internal ICollection<ContentSecurityPolicyDirective> Build()
        {
            return GetDefaultDirectives()
                .Concat(CustomDirectives)
                .ToList();
        }

        private IEnumerable<ContentSecurityPolicyDirective> GetDefaultDirectives()
        {
            return GetType()
                .GetProperties()
                .Where(x => typeof(ContentSecurityPolicyDirectiveBuilder).IsAssignableFrom(x.PropertyType))
                .Select(x => ((ContentSecurityPolicyDirectiveBuilder)x.GetValue(this)).Build());
        }
    }
}