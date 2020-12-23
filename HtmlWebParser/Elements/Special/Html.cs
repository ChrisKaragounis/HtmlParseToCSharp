using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;

namespace HtmlWebParser.Elements.Special
{
    internal class Html : Element
    {
        public new readonly string TagName = "html";

        /// <summary>
        /// Specifies the URI of a resource manifest indicating resources that should be cached locally. See <see href="https://developer.mozilla.org/en-US/docs/Web/HTML/Using_the_application_cache">Using the application cache</see> for details.
        /// </summary>
        public string manifest;

        /// <summary>
        /// Specifies the version of the HTML  <see href="https://developer.mozilla.org/en-US/docs/Glossary/Doctype">Document Type Definition</see> that governs the current document. This attribute is not needed, because it is redundant with the version information in the document type declaration.
        /// </summary>
        public string version;

        /// <summary>
        /// Specifies the XML Namespace of the document. Default value is "http://www.w3.org/1999/xhtml". This is required in documents parsed with XML parsers, and optional in text/html documents.
        /// </summary>
        public string xmlns;
        public readonly HtmlObjectType tagType = HtmlObjectType.SelfClosingTag;


        public Html(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key.Trim())
                {
                    case "manifest":
                        manifest = value;
                        break;

                    case "version":
                        version = value;
                        break;

                    case "xmlns":
                        xmlns = value;
                        break;
                }
            }
        }
    }
}