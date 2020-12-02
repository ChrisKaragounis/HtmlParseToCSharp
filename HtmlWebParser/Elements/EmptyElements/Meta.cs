using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;

namespace HtmlWebParser.Elements.EmptyElements
{
    internal class Meta : Element
    {
        public new readonly string TagName = "meta";
        public string charset;
        public string content;
        public string httpequiv;
        public string name;

        public Meta(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key.Trim())
                {
                    case "charset":
                        charset = value;
                        break;

                    case "content":
                        content = value;
                        break;

                    case "http-equiv":
                        httpequiv = value;
                        break;

                    case "name":
                        name = value;
                        break;

                    default:
                        //UnknownElementPropertyFound(key, value, this);
                        break;
                }
            }
        }
    }
}