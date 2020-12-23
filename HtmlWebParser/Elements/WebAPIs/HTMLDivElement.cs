using System;
using System.Collections.Generic;
using System.Text;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.WebAPIs
{
    public abstract class HTMLDivElement : HTMLElement
    {
        /// <summary>
        /// Is a DOMString representing an enumerated property indicating alignment of the element's contents with respect to the surrounding context. The possible values are "left", "right", "justify", and "center".
        /// </summary>
        public string align;
        public HTMLDivElement(HtmlObject obj) : base(obj)
        {
        }
    }
}
