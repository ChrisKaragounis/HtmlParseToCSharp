using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.BlockElements
{
    class Nav : HTMLElement
    {
        public new readonly string TagName = "nav";
        public Nav(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}
