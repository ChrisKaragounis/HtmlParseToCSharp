using HtmlWebParser.Elements.WebAPIs;
using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;

namespace HtmlWebParser.Elements.BlockElements
{
    internal class H3 : HTMLHeadingElement
    {
        public new readonly string TagName = "h3";

        public H3(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}