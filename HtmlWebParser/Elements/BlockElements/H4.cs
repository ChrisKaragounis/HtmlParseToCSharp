using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HtmlWebParser.Elements.WebAPIs;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.BlockElements
{
    class H4 : HTMLHeadingElement
    {
        public new readonly string TagName = "h4";

        public H4(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}