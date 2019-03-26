using System;

namespace Vivelin.AspNetCore.Headers
{
    /// <summary>
    /// Provides an API for configuring a Content Security Policy directive that
    /// contains a list of media types.
    /// </summary>
    public class ContentSecurityPolicyMediaTypeDirectiveBuilder : ContentSecurityPolicyDirectiveBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="ContentSecurityPolicyMediaTypeDirectiveBuilder"/> class with
        /// the specified directive name.
        /// </summary>
        /// <param name="name">The name of a fetch directive.</param>
        public ContentSecurityPolicyMediaTypeDirectiveBuilder(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Returns the <see cref="ContentSecurityPolicyDirective"/> constructed
        /// by the builder.
        /// </summary>
        /// <param name="builder">
        /// A <see cref="ContentSecurityPolicyMediaTypeDirectiveBuilder"/> whose
        /// directive to return.
        /// </param>
        public static implicit operator ContentSecurityPolicyDirective(ContentSecurityPolicyMediaTypeDirectiveBuilder builder)
        {
            return builder.Build();
        }

        /// <summary>
        /// Adds a media type to the directive.
        /// </summary>
        /// <param name="mediaType">
        /// The media type to add to the directive.
        /// </param>
        /// <returns>A reference to the current instance.</returns>
        public new ContentSecurityPolicyMediaTypeDirectiveBuilder Add(string mediaType)
        {
            base.Add(mediaType);
            return this;
        }
    }
}