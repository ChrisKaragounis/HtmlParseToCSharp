using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace HtmlWebParser.Elements.Special
{
    internal class Body : Element
    {
        public new readonly string TagName = "body";

        /// <summary>
        /// Color of text for hyperlinks when selected. This method is non-conforming, use CSS color property in conjunction with the :active pseudo-class instead.
        /// </summary>
        public string alink;

        public Body(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key.Trim())
                {
                    case "alink":
                        alink = value;
                        break;

                    default:
                        Debug.WriteLine("Unknown entry found");
                        break;
                }
            }
        }
    }
}