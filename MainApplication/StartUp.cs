using System;
using HtmlWebParser.Entities;
using HtmlWebParser.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace MainApplication
{
    internal class StartUp
    {
        public static void Start()
        {
            string content = ContentProvider.GetContent();
            HtmlParser parser = new HtmlParser(content);
            Webpage webpage = parser.Parse();
            //using System.IO.StreamWriter file =
            //    new System.IO.StreamWriter(@"D:\Users\Christos\Downloads\Compressed\WriteLines2.html", false);
            //foreach (HtmlObject htmlObject in webpage)
            //{
            //    file.Write(htmlObject.ToString());
            //}
        }
    }
}