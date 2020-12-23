using HtmlWebParser.Elements;
using HtmlWebParser.Elements.BlockElements;
using HtmlWebParser.Elements.EmptyElements;
using HtmlWebParser.Elements.InlineElements;
using HtmlWebParser.Elements.Special;
using System;
using System.Collections.Generic;

namespace HtmlWebParser.Entities
{
    /// <summary>
    /// An object representing HTML tags
    /// </summary>
    public class HtmlObject
    {
        private string _name = "";
        public string Name { get => _name; set => _name = value.Trim(); }
        public HtmlObjectType Type;
        private uint _depth;

        public uint Depth
        {
            get => _depth;
            set => _depth = value;
        }

        public Dictionary<string, string> Properties = new Dictionary<string, string>();

        public HtmlObject()
        {
        }

        public HtmlObject(string tagName, HtmlObjectType type)
        {
            this._name = tagName;
            this.Type = type;
        }

        public Element ToElement()
        {
            switch (this.Name.Trim().ToLower())
            {
                /* Begin - Block Elements*/
                case "div":
                    return new Div(this);

                case "h1":
                    return new H1(this);

                case "h2":
                    return new H2(this);

                case "h3":
                    return new H3(this);

                case "h4":
                    return new H4(this);

                case "h5":
                    return new H5(this);

                case "h6":
                    return new H6(this);

                case "li":
                    return new LI(this);

                case "main":
                    return new Main(this);

                case "nav":
                    return new Nav(this);

                case "p":
                    return new P(this);

                case "ul":
                    return new UL(this);
                /* End - Block Elements*/
                /* Begin - Empty Elements*/

                case "area":
                    return new Area(this);

                case "meta":
                    return new Meta(this);
                /* End - Empty Elements*/
                /* Begin - Inline Elements*/

                case "a":
                    return new A(this);

                case "img":
                    return new IMG(this);

                case "strong":
                    return new Strong(this);
                /* End - Inline Elements*/
                /* Begin - Special Elements*/

                case "body":
                    return new Body(this);

                case "head":
                    return new Head(this);

                case "html":
                    return new Html(this);

                case "title":
                    return new Title(this);

                /* End - Special Elements*/

                default: return null;
            }
        }

        public override string ToString()
        {
            //return Name;
            string toReturn = "";

            switch (this.Type)
            {
                case HtmlObjectType.OpeningTag:
                case HtmlObjectType.SelfClosingTag:
                    toReturn += "<";
                    break;

                case HtmlObjectType.ClosingTag:
                    toReturn += "</";
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            toReturn += this.Name;

            bool hasInBetweenContent = false;
            foreach (KeyValuePair<string, string> entry in Properties)
            {
                if (entry.Key.Equals("InBetweenContent"))
                {
                    toReturn += ">" + entry.Value;
                    hasInBetweenContent = true;
                }
                else
                    toReturn += " " + entry.Key.ToString() + "=\"" + entry.Value;
            }
            toReturn = toReturn.TrimEnd();
            if (hasInBetweenContent)
                return toReturn;

            switch (this.Type)
            {
                case HtmlObjectType.SelfClosingTag:
                    toReturn += "/>";
                    break;

                case HtmlObjectType.ClosingTag:
                case HtmlObjectType.OpeningTag:
                    toReturn += ">";
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            return toReturn;
        }
    }
}