using System;

namespace Vivelin.AspNetCore.Headers
{
    /// <summary>
    /// Provides a set of static methods for specfiying a user agent's content
    /// type options.
    /// </summary>
    public static class ContentTypeOptionsExtensions
    {
        /// <summary>
        /// Specifies that user agents should block requests where the declared
        /// content type does not match the expected content type.
        /// </summary>
        /// <param name="builder">
        /// The builder being used to configure the response headers.
        /// </param>
        /// <returns>
        /// A reference to <paramref name="builder"/> without XSS protection.
        /// </returns>
        public static ResponseHeadersOptionsBuilder PreventContentTypeSniffing(this ResponseHeadersOptionsBuilder builder)
            => builder.Add("X-Content-Type-Options", "nosniff");
    }
}