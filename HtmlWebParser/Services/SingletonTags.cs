using HtmlWebParser.Entities;
using System.Collections.Generic;

namespace HtmlWebParser.Services
{
    public static class SingletonTags
    {
        public static readonly List<HtmlObject> Singletons = new List<HtmlObject>()
        {
            new HtmlObject {Name="area"},
            new HtmlObject {Name="base"},
            new HtmlObject {Name="br"},
            new HtmlObject {Name="col"},
            new HtmlObject {Name="command"},
            new HtmlObject {Name="embed"},
            new HtmlObject {Name="hr"},
            new HtmlObject {Name="img"},
            new HtmlObject {Name="input"},
            new HtmlObject {Name="keygen"},
            new HtmlObject {Name="link"},
            new HtmlObject {Name="meta"},
            new HtmlObject {Name="param"},
            new HtmlObject {Name="source"},
            new HtmlObject {Name="track"},
            new HtmlObject {Name="wbr"},
        };

        public static bool isSingleton(HtmlObject Input)
        {
            foreach (HtmlObject obj in Singletons)
            {
                if (Compare(obj, Input))
                    return true;
            }
            return false;
        }

        private static bool Compare(HtmlObject First, HtmlObject Second)
        {
            if (First.Name == Second.Name)
                return true;
            return false;
        }
    }
}