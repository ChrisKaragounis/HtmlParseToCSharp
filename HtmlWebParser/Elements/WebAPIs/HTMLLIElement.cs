using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.WebAPIs
{
    internal abstract class HTMLLIElement : HTMLElement
    {
        /// <summary>
        /// Is a DOMString representing the type of the bullets, "disc", "square" or "circle". As the standard way of defining the list type is via the CSS list-style-type property, use the CSSOM methods to set it via a script.
        /// </summary>
        public string type;

        /// <summary>
        /// Is a long indicating the ordinal position of the list element inside a given <ol>. It reflects the value attribute of the HTML <li> element, and can be smaller than 0. If the <li> element is not a child of an <ol> element, the property has no meaning.
        /// </summary>
        public string value;

        public HTMLLIElement(HtmlObject obj) : base(obj)
        {
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key)
                {
                    case "type":
                        type = value;
                        break;

                    case "value":
                        this.value = value;
                        break;
                }
            }
        }
    }
}