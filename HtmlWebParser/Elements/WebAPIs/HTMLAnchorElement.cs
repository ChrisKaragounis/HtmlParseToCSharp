using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements
{
    abstract class HTMLAnchorElement : HTMLElement, HTMLHyperlinkElementUtils
    {
        public HTMLAnchorElement(HtmlObject obj) : base(obj)
        {
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key.Trim())
                {
                    case "href":
                        href = value;
                        break;
                    case "protocol":
                        protocol = value;
                        break;
                    case "host":
                        host = value;
                        break;
                    case "hostname":
                        hostname = value;
                        break;
                    case "search":
                        search = value;
                        break;
                    case "hash":
                        hash = value;
                        break;
                    case "username":
                        username = value;
                        break;
                    case "password":
                        password = value;
                        break;
                    case "origin":
                        origin = value;
                        break;
                }
            }
        }

        public string href { get; set; }
        public string protocol { get; set; }
        public string host { get; set; }
        public string hostname { get; set; }
        public string port { get; set; }
        public string pathname { get; set; }
        public string search { get; set; }
        public string hash { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string origin { get; set; }
    }
}