using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.InlineElements
{
    class Strong : HTMLElement
    {
        public new readonly string TagName = "strong";

        public Strong(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}