using HtmlWebParser.Elements.WebAPIs;
using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;

namespace HtmlWebParser.Elements.BlockElements
{
    internal class H6 : HTMLHeadingElement
    {
        public new readonly string TagName = "h6";

        public H6(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}