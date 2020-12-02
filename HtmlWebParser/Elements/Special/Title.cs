using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HtmlWebParser.Elements.WebAPIs;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.Special
{
    class Title : HTMLTitleElement
    {
        public new readonly string TagName = "title";

        public Title(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}
