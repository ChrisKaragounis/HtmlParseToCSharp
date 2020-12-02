using HtmlWebParser.Entities;
using System;

namespace HtmlWebParser.Services
{
    public partial class HtmlParser
    {
        private readonly char[] _content;

        /// <summary>
        /// Injects the HTML content to the HTMLParser
        /// </summary>
        /// <param name="content">HTML Content in string fomat</param>
        public HtmlParser(string content)
        {
            //content.Replace(System.Environment.NewLine, "");
            this._content = content.ToCharArray();
        }

        private Webpage Analyze()
        {
            Webpage _webpage = new Webpage();
            int endOfFile = GetEndOfFile();
            HtmlObject htmlTag = new HtmlObject();
            bool inBetweenContentAfterClosedTagFound = false;
            string inBetweenContentAfterClosedTag = "";

            for (int i = 0; i < endOfFile - 1; i++)
            {
                switch (_content[i])
                {
                    case '/': // comment maybe /* */
                        {
                            if (_content[++i] == '*')
                            {
                                while (_content[i].ToString() + _content[i + 1] != "*/")
                                {
                                    i++;
                                }
                            }
                            break;
                        }
                    case '<':
                        //move one point forward cause right now it shows "<"
                        switch (_content[++i])
                        {
                            case '!':
                                i = SkipComment(i);
                                break;

                            case { } c when (char.IsLetter(c)):
                                {
                                    if (htmlTag.Name != "")
                                    {
                                        _webpage.Add(htmlTag);
                                        htmlTag = new HtmlObject();
                                    }
                                    Tuple<int, HtmlObject> values = GetOpeningTagName(i);
                                    htmlTag = values.Item2;
                                    i = values.Item1;
                                    if (inBetweenContentAfterClosedTagFound)
                                    {
                                        int result = GetInBetweenContentParent(_webpage, htmlTag);
                                        if (result > 0)
                                        {
                                            try
                                            {
                                                _webpage[result].Properties.Add("InBetweenContent", inBetweenContentAfterClosedTag);
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e);
                                            }
                                        }
                                        inBetweenContentAfterClosedTagFound = false;
                                    }
                                }
                                break;

                            case '/':
                                {
                                    if (htmlTag.Name != "")
                                    {
                                        _webpage.Add(htmlTag);
                                    }
                                    Tuple<int, string> values = GetClosingTagName(++i);
                                    htmlTag = new HtmlObject(values.Item2,HtmlObjectType.ClosingTag);
                                    i = values.Item1;

                                    if (inBetweenContentAfterClosedTagFound)
                                    {
                                        int result = GetInBetweenContentParent(_webpage, htmlTag);
                                        if (result > 0)
                                        {
                                            HtmlObject obj = _webpage[result];
                                            try
                                            {
                                                _webpage[result].Properties.Add("InBetweenContent", inBetweenContentAfterClosedTag);
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e);
                                            }
                                        }
                                        inBetweenContentAfterClosedTagFound = false;
                                    }
                                }
                                break;
                        }
                        break;
                    //Create a case for the content inside <p>Hello</p>
                    case '>':
                        {
                            if (htmlTag.Type == HtmlObjectType.OpeningTag)
                            {
                                Tuple<int, string> values = GetInBetweenContent(i, endOfFile, htmlTag);
                                if (!String.IsNullOrWhiteSpace(values.Item2))
                                {
                                    htmlTag.Properties.Add("InBetweenContent", values.Item2);
                                }
                                i = values.Item1;
                            }
                        }
                        break;
                    //We are probably(?) reading a property
                    case { } c when (Char.IsLetter(c)):
                        {
                            if (htmlTag.Type == HtmlObjectType.OpeningTag)
                            {
                                Tuple<int, HtmlObject> values = GetProperties(i, endOfFile, htmlTag);
                                i = values.Item1;
                                htmlTag = values.Item2;
                            }
                            else
                            {
                                // Temporary solution for skipping characters (i--)
                                i--;
                                Tuple<int, string> values = GetInBetweenContent(i, endOfFile);
                                if (!String.IsNullOrWhiteSpace(values.Item2))
                                {
                                    inBetweenContentAfterClosedTagFound = true;
                                    inBetweenContentAfterClosedTag = values.Item2;
                                }
                                i = values.Item1;
                            }
                        }
                        break;
                }
            }
            if (!htmlTag.Name.Equals(""))
                _webpage.Add(htmlTag);
            return _webpage;
        }
    }
}