using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HtmlWebParser.Elements.WebAPIs;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.BlockElements
{
    /// <summary>
    /// Unordered List
    /// </summary>
    class UL :HTMLUListElement
    {
        public new readonly string TagName = "ul";

        /// <summary>
        /// This attribute sets the bullet style for the list.
        /// </summary>
        public string type;
        /// <summary>
        /// This Boolean attribute hints that the list should be rendered in a compact style. The interpretation of this attribute depends on the user agent, and it doesn't work in all browsers.
        /// </summary>
        public string compact;

        public UL(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
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
