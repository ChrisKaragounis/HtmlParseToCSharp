using System;
using System.Collections.Generic;
using System.Text;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.WebAPIs
{
    abstract class HTMLTitleElement : HTMLElement
    {
        /// <summary>
        /// Is a DOMString representing the text of the document's title.
        /// </summary>
        public string text;
        public HTMLTitleElement(HtmlObject obj) : base(obj)
        {
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key)
                {
                    case "inBetweenContent":
                        text = value;
                        break;
                }
            }
        }
    }
}
