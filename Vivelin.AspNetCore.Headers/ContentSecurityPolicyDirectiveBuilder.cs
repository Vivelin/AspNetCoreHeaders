using System;

namespace Vivelin.AspNetCore.Headers
{
    /// <summary>
    /// Provides an API for configuring a Content Security Policy directive.
    /// </summary>
    public abstract class ContentSecurityPolicyDirectiveBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="ContentSecurityPolicyDirectiveBuilder"/> class with the
        /// specified directive name.
        /// </summary>
        /// <param name="name">The name of a directive.</param>
        protected ContentSecurityPolicyDirectiveBuilder(string name)
        {
            Directive = new ContentSecurityPolicyDirective(name);
        }

        /// <summary>
        /// Gets the directive being configured.
        /// </summary>
        protected ContentSecurityPolicyDirective Directive { get; }

        /// <summary>
        /// Returns the <see cref="ContentSecurityPolicyDirective"/> constructed
        /// by the builder.
        /// </summary>
        /// <param name="builder">
        /// A <see cref="ContentSecurityPolicyDirectiveBuilder"/> whose directive
        /// to return.
        /// </param>
        public static implicit operator ContentSecurityPolicyDirective(ContentSecurityPolicyDirectiveBuilder builder)
        {
            return builder.Build();
        }

        /// <summary>
        /// Adds a value to the directive.
        /// </summary>
        /// <param name="value">The value to add to the directive.</param>
        /// <returns>A reference to the current instance.</returns>
        public virtual ContentSecurityPolicyDirectiveBuilder Add(string value)
        {
            Directive.Values.Add(value);
            return this;
        }

        /// <summary>
        /// Returns the <see cref="ContentSecurityPolicyDirective"/> constructed
        /// by the builder.
        /// </summary>
        /// <returns>
        /// A <see cref="ContentSecurityPolicyDirective"/> constructed by the
        /// builder.
        /// </returns>
        protected internal ContentSecurityPolicyDirective Build()
        {
            return Directive;
        }
    }
}