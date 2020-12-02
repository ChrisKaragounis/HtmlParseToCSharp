using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements
{
    public abstract class Element : GlobalAttributes
    {
        public string TagName { get; set; }
        public uint Depth;

        public Element(HtmlObject obj) : base(obj)
        {
        }

        public override string ToString()
        {
            return TagName;
        }
    }
}