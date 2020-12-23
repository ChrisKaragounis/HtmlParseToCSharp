using System.ComponentModel.DataAnnotations;
using HtmlWebParser.Elements.WebAPIs;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.BlockElements
{
    internal class P : HTMLParagraphElement
    {
        public readonly HtmlObjectType tagType = HtmlObjectType.SelfClosingTag;

        public new readonly string TagName = "p";
        public P(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}