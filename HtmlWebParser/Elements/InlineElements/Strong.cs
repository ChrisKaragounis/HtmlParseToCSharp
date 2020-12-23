using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;

namespace HtmlWebParser.Elements.InlineElements
{
    internal class Strong : HTMLElement
    {
        public new readonly string TagName = "strong";

        public Strong(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}