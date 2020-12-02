using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements
{
    public class HTMLElement : Element
    {
        /// <summary>
        /// Represents the "rendered" text content of a node and its descendants. As a getter, it approximates the text the user would get if they highlighted the contents of the element with the cursor and then copied it to the clipboard.
        /// </summary>
        public string innerText;

        public HTMLElement(HtmlObject obj) : base(obj)
        {
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key)
                {
                    case "InBetweenContent":
                        innerText = value;
                        break;
                }
            }
        }
    }
}