using System;

namespace Vivelin.AspNetCore.Headers
{
    /// <summary>
    /// Provides a set of static methods for specifying the feature policy of an
    /// application.
    /// </summary>
    public static class FeaturePolicyExtensions
    {
        /// <summary>
        /// Specifies a feature policy.
        /// </summary>
        /// <param name="builder">
        /// The builder being used to configure the response headers.
        /// </param>
        /// <param name="value">
        /// A string that contains the serialized feature policy.
        /// </param>
        /// <returns>
        /// A reference to <paramref name="builder"/> with the specified feature
        /// policy.
        /// </returns>
        public static ResponseHeadersOptionsBuilder AddFeaturePolicy(this ResponseHeadersOptionsBuilder builder, string value)
            => builder.Add("Feature-Policy", value);
    }
}