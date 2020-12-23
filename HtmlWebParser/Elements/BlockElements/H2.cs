using HtmlWebParser.Elements.WebAPIs;
using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;

namespace HtmlWebParser.Elements.BlockElements
{
    internal class H2 : HTMLHeadingElement
    {
        public new readonly string TagName = "h2";

        public H2(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}