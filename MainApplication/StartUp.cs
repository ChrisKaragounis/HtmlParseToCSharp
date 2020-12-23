using DynamicAPI;
using HtmlWebParser.Entities;
using HtmlWebParser.Services;

namespace MainApplication
{
    internal class StartUp
    {
        public static void Start()
        {
            string content = ContentProvider.GetContent();
            HtmlParser parser = new HtmlParser(content);
            Webpage webpage = parser.Parse();
            API api = new API(webpage); 
            //using System.IO.StreamWriter file =
            //    new System.IO.StreamWriter(@"D:\Users\Christos\Downloads\Compressed\WriteLines2.html", false);
            //foreach (HtmlObject htmlObject in webpage)
            //{
            //    file.Write(htmlObject.ToString());
            //}
        }
    }
}