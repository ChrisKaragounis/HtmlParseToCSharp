using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.EmptyElements
{
    class Area : Elements.Element
    {
        public new readonly string TagName = "area";

        public Area(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
        }
    }
}
