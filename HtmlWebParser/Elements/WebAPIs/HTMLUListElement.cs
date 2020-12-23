using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.WebAPIs
{
    public abstract class HTMLUListElement : HTMLElement
    {
        /// <summary>
        /// Is a DOMString value reflecting the type and defining the kind of marker to be used to display. The values are browser dependent and have never been standardized.
        /// </summary>
        public string type;

        /// <summary>
        /// Is a Boolean indicating that spacing between list items should be reduced. This property reflects the compact attribute only, it doesn't consider the line-height CSS property used for that behavior in modern pages.
        /// </summary>
        public string compact;

        public HTMLUListElement(HtmlObject obj) : base(obj)
        {
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key)
                {
                    case "type":
                        type = value;
                        break;

                    case "compact":
                        compact = value;
                        break;
                }
            }
        }
    }
}