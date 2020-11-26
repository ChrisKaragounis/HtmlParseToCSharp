using HtmlWebParser.Entities;
using HtmlWebParser.Services;
using System.Collections.Generic;

namespace MainApplication
{
    internal class StartUp
    {
        static public void Start()
        {
            string content = ContentProvider.getContentAsync();
            HtmlParser parser = new HtmlParser(content);
            List<HtmlObject> Webpage = parser.Parse();
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"D:\Users\Christos\Downloads\Compressed\WriteLines2.html", false))
            {
                foreach (HtmlObject htmlObject in Webpage)
                {
                    file.Write(htmlObject.ToString());
                }
            }
            //parser = new HtmlParser("<p>hello</p>");
            //Webpage = (List<HtmlObject>)parser.Result();
        }
    }
}