using HtmlWebParser.Entities;
using System;
using System.Collections.Generic;

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
            content.Replace(System.Environment.NewLine, "");
            this._content = content.ToCharArray();
        }

        private List<HtmlObject> Analyze()
        {
            List<HtmlObject> HtmlObjectsList = new List<HtmlObject>();
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
                                        HtmlObjectsList.Add(htmlTag);
                                        htmlTag = new HtmlObject();
                                    }
                                    Tuple<int, HtmlObject> values = GetOpeningTagName(i);
                                    htmlTag = values.Item2;
                                    i = values.Item1;
                                    if (inBetweenContentAfterClosedTagFound)
                                    {
                                        int result = GetInBetweenContentParent(HtmlObjectsList, htmlTag);
                                        if (result > 0)
                                        {
                                            HtmlObjectsList[result].Properties.Add("InBetweenContent", inBetweenContentAfterClosedTag);
                                        }
                                        inBetweenContentAfterClosedTagFound = false;
                                    }
                                }
                                break;

                            case '/':
                                {
                                    if (htmlTag.Name != "")
                                    {
                                        HtmlObjectsList.Add(htmlTag);
                                        htmlTag = new HtmlObject();
                                    }
                                    Tuple<int, HtmlObject> values = GetClosingTagName(++i);
                                    htmlTag = values.Item2;
                                    i = values.Item1;

                                    if (inBetweenContentAfterClosedTagFound)
                                    {
                                        int result = GetInBetweenContentParent(HtmlObjectsList, htmlTag);
                                        if (result > 0)
                                        {
                                            try
                                            {
                                                HtmlObjectsList[result].Properties.Add("InBetweenContent", inBetweenContentAfterClosedTag);
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
                            if (htmlTag.type == HtmlObjectType.OpeningTag)
                            {
                                Tuple<int, HtmlObject> values = GetInBetweenContent(i, endOfFile, htmlTag);
                                i = values.Item1;
                                htmlTag = values.Item2;
                            }
                        }
                        break;
                    //We are probably(?) reading a property
                    case Char c when (Char.IsLetter(c)):
                        {
                            if (htmlTag.type == HtmlObjectType.OpeningTag)
                            {
                                Tuple<int, HtmlObject> values = GetProperties(i, endOfFile, htmlTag);
                                i = values.Item1;
                                htmlTag = values.Item2;
                            }
                            else
                            {
                                // Temporary solution for skipping characters (i--)
                                i--;
                                Tuple<int, HtmlObject> values = GetInBetweenContent(i, endOfFile, new HtmlObject());
                                inBetweenContentAfterClosedTagFound = true;
                                inBetweenContentAfterClosedTag = values.Item2.Properties["InBetweenContent"];
                                i = values.Item1;
                            }
                        }
                        break;
                }
            }
            if (!htmlTag.Name.Equals(""))
                HtmlObjectsList.Add(htmlTag);
            return HtmlObjectsList;
        }
    }
}