using System.Collections.Generic;

namespace HtmlWebParser.Entities
{
    /// <summary>
    /// An object representing HTML tags
    /// </summary>
    public class HtmlObject
    {
        private string name = "";
        public HtmlObjectType type;
        public int depth;

        public Dictionary<string, string> Properties;

        public string Name { get => name; set => name = value; }

        public HtmlObject()
        {
            this.Properties = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            //return Name;
            string toReturn = "";

            if (this.type == HtmlObjectType.OpeningTag || this.type == HtmlObjectType.SelfClosingTag)
                toReturn += "<";
            else if (this.type == HtmlObjectType.ClosingTag)
                toReturn += "</";

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

            if (this.type == HtmlObjectType.SelfClosingTag)
                toReturn += "/>";
            else if (this.type == HtmlObjectType.ClosingTag || this.type == HtmlObjectType.OpeningTag)
                toReturn += ">";
            return toReturn;
        }
    }
}