using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.BlockElements
{
    class Main : HTMLElement
    {
        public new readonly string TagName = "main";
        public Main(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}
