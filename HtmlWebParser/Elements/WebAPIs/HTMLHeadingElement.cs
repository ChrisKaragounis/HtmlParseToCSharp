using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.WebAPIs
{
    public abstract class HTMLHeadingElement : HTMLElement
    {
        /// <summary>
        /// Is a DOMString representing an enumerated attribute indicating alignment of the heading with respect to the surrounding context. The possible values are "left", "right", "justify", and "center".
        /// </summary>
        public string align;

        public HTMLHeadingElement(HtmlObject obj) : base(obj)
        {
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key)
                {
                    case "align":
                        align = value;
                        break;
                }
            }
        }
    }
}