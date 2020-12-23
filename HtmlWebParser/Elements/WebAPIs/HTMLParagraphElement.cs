using System;
using System.Collections.Generic;
using System.Text;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.WebAPIs
{
   abstract class HTMLParagraphElement  : HTMLElement
   {
        /// <summary>
        /// A DOMString representing an enumerated property indicating alignment of the element's contents with respect to the surrounding context. The possible values are "left", "right", "justify", and "center"
        /// </summary>
        public string align;
        protected HTMLParagraphElement(HtmlObject obj) : base(obj)
        {
        }
    }
}
