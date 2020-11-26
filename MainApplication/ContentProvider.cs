using System;
using System.IO;
using System.Text;

namespace MainApplication
{
    public static class ContentProvider
    {
        public static string getContentAsync()
        {
            FileStream fileStream = new FileStream("Files/lagonika.html", FileMode.Open);
            String content;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1253 = Encoding.GetEncoding(1253);

            using (StreamReader reader = new StreamReader(fileStream, enc1253))
            {
                content = reader.ReadToEnd();
            }
            //string output = new string(content.Where(c => !char.IsControl(c)).ToArray());
            return content;
        }
    }
}