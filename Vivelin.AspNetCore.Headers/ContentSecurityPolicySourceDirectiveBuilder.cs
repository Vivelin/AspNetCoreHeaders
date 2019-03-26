using System;

namespace Vivelin.AspNetCore.Headers
{
    /// <summary>
    /// Provides an API for configuring a Content Security Policy directive that
    /// contains a list of sources.
    /// </summary>
    public class ContentSecurityPolicySourceDirectiveBuilder : ContentSecurityPolicyDirectiveBuilder
    {
        private const string None = "'none'";
        private const string Self = "'self'";
        private const string StrictDynamic = "'strict-dynamic'";
        private const string UnsafeEval = "'unsafe-eval'";
        private const string UnsafeInline = "'unsafe-inline'";

        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="ContentSecurityPolicySourceDirectiveBuilder"/> class with
        /// the specified directive name.
        /// </summary>
        /// <param name="name">The name of a fetch directive.</param>
        public ContentSecurityPolicySourceDirectiveBuilder(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Returns the <see cref="ContentSecurityPolicyDirective"/> constructed
        /// by the builder.
        /// </summary>
        /// <param name="builder">
        /// A <see cref="ContentSecurityPolicySourceDirectiveBuilder"/> whose
        /// directive to return.
        /// </param>
        public static implicit operator ContentSecurityPolicyDirective(ContentSecurityPolicySourceDirectiveBuilder builder)
        {
            return builder.Build();
        }

        /// <summary>
        /// Adds a value to the directive.
        /// </summary>
        /// <param name="value">The value to add to the directive.</param>
        /// <returns>A reference to the current instance.</returns>
        /// <exception cref="InvalidOperationException">
        /// Adding additional values to a directive after disallowing all
        /// requests will have no effect.
        /// </exception>
        public new ContentSecurityPolicySourceDirectiveBuilder Add(string value)
        {
            if (Directive.Values.Contains(None))
                throw new InvalidOperationException("Adding additional values to a directive after disallowing all requests will have no effect.");

            base.Add(value);
            return this;
        }

        /// <summary>
        /// Specifies that the unsafe evaluation of scripts or styles is allowed.
        /// </summary>
        /// <returns>A reference to the current instance.</returns>
        public ContentSecurityPolicySourceDirectiveBuilder AllowEval() => Add(UnsafeEval);

        /// <summary>
        /// Specifies that everything on the specified origin is allowed.
        /// </summary>
        /// <param name="origin">
        /// The origin to allow, e.g. <c>https://example.com/</c>.
        /// </param>
        /// <returns>A reference to the current instance.</returns>
        public ContentSecurityPolicySourceDirectiveBuilder AllowFromOrigin(string origin) => Add(origin);

        /// <summary>
        /// Specifies that any resource with the specified scheme is allowed.
        /// </summary>
        /// <param name="scheme">The scheme to allow, e.g. <c>data:</c>.</param>
        /// <returns>A reference to the current instance.</returns>
        public ContentSecurityPolicySourceDirectiveBuilder AllowFromScheme(string scheme) => Add(scheme);

        /// <summary>
        /// Specifies that everything on the current origin is allowed.
        /// </summary>
        /// <returns>A reference to the current instance.</returns>
        public ContentSecurityPolicySourceDirectiveBuilder AllowFromSelf() => Add(Self);

        /// <summary>
        /// Specifies that the specified URL is allowed.
        /// </summary>
        /// <param name="url">
        /// The full URL to allow, e.g.
        /// <c>https://example.com/path/to/file.js</c>.
        /// </param>
        /// <returns>A reference to the current instance.</returns>
        public ContentSecurityPolicySourceDirectiveBuilder AllowFromUrl(string url) => Add(url);

        /// <summary>
        /// Specifies that requests from the specified host are allowed,
        /// regardless of scheme.
        /// </summary>
        /// <param name="host">
        /// The host to allow, e.g. <c>example.com</c> or <c>*.example.com</c>.
        /// </param>
        /// <returns>A reference to the current instance.</returns>
        public ContentSecurityPolicySourceDirectiveBuilder AllowHost(string host) => Add(host);

        /// <summary>
        /// Specifies that unsafe execution of inline scripts or styles is
        /// allowed.
        /// </summary>
        /// <returns>A reference to the current instance.</returns>
        public ContentSecurityPolicySourceDirectiveBuilder AllowInline() => Add(UnsafeInline);

        /// <summary>
        /// Specifies that nothing is allowed.
        /// </summary>
        /// <returns>A reference to the current instance.</returns>
        public ContentSecurityPolicySourceDirectiveBuilder DisallowAll() => Add(None);

        /// <summary>
        /// Specifies the 'strict-dynamic' expression.
        /// </summary>
        /// <returns>A reference to the current instance.</returns>
        public ContentSecurityPolicySourceDirectiveBuilder Dynamic() => Add(StrictDynamic);
    }
}