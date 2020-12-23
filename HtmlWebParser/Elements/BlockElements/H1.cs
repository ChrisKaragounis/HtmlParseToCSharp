using HtmlWebParser.Elements.WebAPIs;
using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;

namespace HtmlWebParser.Elements.BlockElements
{
    internal class H1 : HTMLHeadingElement
    {
        public new readonly string TagName = "h1";

        public H1(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}