using System;
using System.IO;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Abiosoft.DotNet.DevReload
{

    /// <summary>
    /// Options to configure DevReload middleware.
    /// </summary>
    public class DevReloadOptions
    {
        /// <summary>
        /// Directory to watch for file changes.
        /// Default: "wwwroot".
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// SubDirectories to ignore.
        /// </summary>
        public string[] IgnoredSubDirectories { get; set; }

        /// <summary>
        /// File extensions to watch, this should only be static files.
        /// Do not include dotnet files like razor and cshtml.
        /// Default: ["js", "css", "html"]
        /// </summary>
        public string[] StaticFileExtensions { get; set; }
    }

    public static class MiddlewareHelpers
    {
        /// <summary>
        /// Use DevReload middleware with the default configurations.
        /// </summary>
        public static IApplicationBuilder UseDevReload(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseDevReload(new DevReloadOptions
            {
                Directory = "./wwwroot",
                IgnoredSubDirectories = new string[] { ".git", ".node_modules" },
                StaticFileExtensions = new string[] { "js", "html", "css", }
            });
        }
        /// <summary>
        /// Use DevReload middleware with custom configuration.
        /// </summary>
        public static IApplicationBuilder UseDevReload(this IApplicationBuilder app, DevReloadOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }


            return app.UseMiddleware<DevReloadMiddleware>(Options.Create(options));
        }
    }

}
