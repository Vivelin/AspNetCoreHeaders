# Vivelin.AspNetCore.Headers
ASP.NET Core middleware for fluently configuring response headers.

## Example usage

```csharp
using Vivelin.AspNetCore.Headers;

// ...

public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    // ...
    
    app.UseResponseHeaders(options =>
    {
        options
            .AddXssProtection(block: true)
            .AddReferrerPolicy(ReferrerPolicy.StrictOrigin)
            .AddContentSecurityPolicy(csp =>
            {
                csp.Default
                    .AllowFromSelf();
                csp.Styles
                    .AllowFromSelf()
                    .AllowFromOrigin("https://fonts.googleapis.com");
                csp.Fonts
                    .AllowFromSelf()
                    .AllowFromOrigin("https://fonts.gstatic.com");
                csp.Fetch
                    .AllowFromSelf()
                    .AllowFromOrigin("https://api.twitch.tv");
                csp.Images
                    .AllowFromSelf()
                    .AllowFromOrigin("https://static-cdn.jtvnw.net");
            });
    });
    
    // ...
}
```
