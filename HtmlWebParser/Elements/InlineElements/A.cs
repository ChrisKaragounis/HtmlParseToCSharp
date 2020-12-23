using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;

// ReSharper disable StringLiteralTypo

namespace HtmlWebParser.Elements.InlineElements
{
    internal class A : HTMLAnchorElement
    {
        public new readonly string TagName = "a";

        /// <summary>
        /// Prompts the user to save the linked URL instead of navigating to it. Can be used with or without a value
        /// </summary>
        public string download;

        /// <summary>
        /// The URL that the hyperlink points to. Links are not restricted to HTTP-based URLs — they can use any URL scheme supported by browsers:
        /// </summary>
        public string href;

        /// <summary>
        /// Hints at the human language of the linked URL. No built-in functionality. Allowed values are the same as the global lang attribute.
        /// </summary>
        public string hreflang;

        /// <summary>
        /// A space-separated list of URLs. When the link is followed, the browser will send POST requests with the body PING to the URLs. Typically for tracking.
        /// </summary>
        public string ping;

        /// <summary>
        /// How much of the referrer to send when following the link. See Referrer-Policy for possible values and their effects.
        /// </summary>
        public string referrerpolicy;

        /// <summary>
        /// The relationship of the linked URL as space-separated link types.
        /// </summary>
        public string rel;

        /// <summary>
        /// Where to display the linked URL, as the name for a browsing context (a tab, window, or <iframe>). The following keywords have special meanings for where to load the URL:
        /// </summary>
        public string target;

        /// <summary>
        /// Hints at the linked URL’s format with a MIME type. No built-in functionality.
        /// </summary>
        public string type;

        /// <summary>
        /// Hinted at the character encoding of the linked URL.
        /// </summary>
        public string charset;

        /// <summary>
        /// Used with the shape attribute. A comma-separated list of coordinates.
        /// </summary>
        public string coords;

        /// <summary>
        /// Was required to define a possible target location in a page. In HTML 4.01, id and name could both be used on <a>, as long as they had identical values.
        /// </summary>
        public string name;

        /// <summary>
        /// Specified a reverse link; the opposite of the rel attribute. Deprecated for being very confusing.
        /// </summary>
        public string rev;

        /// <summary>
        /// The shape of the hyperlink’s region in an image map.
        /// </summary>
        public string shape;

        public A(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key.Trim())
                {
                    case "download":
                        download = value;
                        break;

                    case "href":
                        href = value;
                        break;

                    case "hreflang":
                        hreflang = value;
                        break;

                    case "ping":
                        ping = value;
                        break;

                    case "referrerpolicy":
                        referrerpolicy = value;
                        break;

                    case "rel":
                        rel = value;
                        break;

                    case "target":
                        target = value;
                        break;

                    case "type":
                        type = value;
                        break;

                    case "charset":
                        charset = value;
                        break;

                    case "coords":
                        coords = value;
                        break;

                    case "name":
                        name = value;
                        break;

                    case "rev":
                        rev = value;
                        break;

                    case "shape":
                        shape = value;
                        break;

                    default:
                        //UnknownElementPropertyFound(key, value, this);
                        break;
                }
            }
        }
    }
}