using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;

namespace HtmlWebParser.Elements.Special
{
    internal class Head : Element
    {
        public new readonly string TagName = "head";

        /// <summary>
        ///The URIs of one or more metadata profiles, separated by white space.
        /// </summary>
        public string profile;
        public readonly HtmlObjectType tagType = HtmlObjectType.SelfClosingTag;

        public Head(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key.Trim())
                {
                    case "profile":
                        profile = value;
                        break;
                }
            }
        }
    }
}