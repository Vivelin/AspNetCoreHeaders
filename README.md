# Vivelin.AspNetCore.Headers
ASP.NET Core middleware for fluently configuring response headers.

[![Build status](https://ci.appveyor.com/api/projects/status/ivae1lr38p908ntr?svg=true)](https://ci.appveyor.com/project/Vivelin/aspnetcoreheaders) [![NuGet](https://img.shields.io/nuget/v/Vivelin.AspNetCore.Headers.svg)](https://www.nuget.org/packages/Vivelin.AspNetCore.Headers)


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

The example above will result in the following headers being added to responses:

    x-xss-protection: 1; mode=block
    referrer-policy: strict-origin
    content-security-policy: connect-src 'self' https://api.twitch.tv ; default-src 'self' ; font-src 'self' https://fonts.gstatic.com ; img-src 'self' https://static-cdn.jtvnw.net ; style-src 'self' https://fonts.googleapis.com
