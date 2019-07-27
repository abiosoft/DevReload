# DevReload

Live reload for ASP.NET development.

## Usage

Use the middleware. Usually in `Startup.cs`

```csharp
if (env.IsDevelopment())
{
    app.UseDevReload();
}
```

Then, add the tag helper to your main layout file.

```cshtml
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@addTagHelper *, DevReload

...

<environment include="Development">
    <devreload></devreload>
</environment>
```

And that's all. Just use `dotnet watch run` and your browser will auto reload.

## Configure

You can modify the directories and file extensions.

```csharp
app.UseDevReload(new DevReloadOptions
{
    Directory = "./wwwroot",
    IgnoredSubDirectories = new string[] { ".git", ".node_modules" },
    StaticFileExtensions = new string[] { "css", "js", "html" },
});
```

## Todo

Publish to Nuget.
