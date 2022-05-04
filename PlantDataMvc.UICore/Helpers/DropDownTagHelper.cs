using Framework.Web.Core.Mediator;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Helpers
{
    // TODO: Can we do it this way instead of via HtmlHelper
    [HtmlTargetElement("select", Attributes = "x,y,z", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SelectQueryTagHelper : SelectTagHelper
    {
        private readonly IMediator _mediator;

        public SelectQueryTagHelper(IHtmlGenerator htmlGenerator, IMediator mediator) : base(htmlGenerator)
        {
            _mediator = mediator;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);
        }
    }
}