namespace Vivelin.AspNetCore.Headers
{
    /// <summary>
    /// Provides a set of static methods for specifying whether user agents are
    /// allowed to display pages from the application in a frame.
    /// </summary>
    public static class FrameOptionsExtensions
    {
        /// <summary>
        /// Specifies the value for the <c>X-Frame-Options</c> header.
        /// </summary>
        /// <param name="builder">
        /// The builder being used to configure the response headers.
        /// </param>
        /// <param name="value">The <c>X-Frame-Options</c> header value.</param>
        /// <returns>
        /// A reference to <paramref name="builder"/> with the specified frame
        /// options value.
        /// </returns>
        public static ResponseHeadersOptionsBuilder AddFrameOptions(this ResponseHeadersOptionsBuilder builder, string value)
            => builder.Add("X-Frame-Options", value);

        /// <summary>
        /// Specifies that user agents must not allow pages from this application
        /// to be displayed in any frame, except for pages from the current
        /// origin.
        /// </summary>
        /// <param name="builder">
        /// The builder being used to configure the response headers.
        /// </param>
        /// <returns>
        /// A reference to <paramref name="builder"/> with framing allowed only
        /// from the same origin.
        /// </returns>
        public static ResponseHeadersOptionsBuilder AllowFramingFromSameOrigin(this ResponseHeadersOptionsBuilder builder)
            => builder.AddFrameOptions("SAMEORIGIN");

        /// <summary>
        /// Specifies that user agents must not allow pages from this application
        /// to be displayed in any frame, except for pages from the specified
        /// origin.
        /// </summary>
        /// <param name="builder">
        /// The builder being used to configure the response headers.
        /// </param>
        /// <param name="origin">
        /// The origin that is allowed to display pages from this application in
        /// a frame.
        /// </param>
        /// <returns>
        /// A reference to <paramref name="builder"/> with framing allowed only
        /// from the same origin.
        /// </returns>
        public static ResponseHeadersOptionsBuilder AllowFramingFromOrigin(this ResponseHeadersOptionsBuilder builder, string origin)
            => builder.AddFrameOptions($"ALLOW-FROM {origin}");

        /// <summary>
        /// Specifies that user agents must not allow pages from this application
        /// to be displayed in any frame.
        /// </summary>
        /// <param name="builder">
        /// The builder being used to configure the response headers.
        /// </param>
        /// <returns>
        /// A reference to <paramref name="builder"/> with framing disabled.
        /// </returns>
        public static ResponseHeadersOptionsBuilder PreventFraming(this ResponseHeadersOptionsBuilder builder)
            => builder.AddFrameOptions("DENY");
    }
}