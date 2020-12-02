using System;
using System.IO;
using System.Text;

namespace MainApplication
{
    public static class ContentProvider
    {
        public static string GetContent()
        {
            FileStream fileStream = new FileStream("Files/lagonika.html", FileMode.Open);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //var enc1253 = Encoding.GetEncoding(1253);
            Encoding enc1253 = Encoding.UTF8;
            using StreamReader reader = new StreamReader(fileStream, enc1253);
            string content = reader.ReadToEnd();
            return content;
        }
    }
}