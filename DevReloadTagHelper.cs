using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DevReload
{
    /// <summary>
    /// Tag helper to inject auto-reload script on webpage.
    /// Add to main layout file.
    /// </summary>
    [HtmlTargetElement("devreload")]
    public class DevReloadTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml(Js.Tag);
        }
    }


}