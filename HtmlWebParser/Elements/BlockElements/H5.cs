using HtmlWebParser.Elements.WebAPIs;
using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;

namespace HtmlWebParser.Elements.BlockElements
{
    internal class H5 : HTMLHeadingElement
    {
        public new readonly string TagName = "h5";

        public H5(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}