using HtmlWebParser.Elements;
using System.Diagnostics;

namespace HtmlWebParser.Services
{
    public static class DebugMessagesProvider
    {
        public static void UnknownElementPropertyFound(string key, string value, Element e)
        {
            Debug.Write("Warning: Property: " + key + " with value: " + value + " in element: " + e.TagName + " Not found");
        }
    }
}