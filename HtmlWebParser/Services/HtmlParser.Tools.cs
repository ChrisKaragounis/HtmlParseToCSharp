using HtmlWebParser.Entities;
using System;
using System.Collections.Generic;

namespace HtmlWebParser.Services
{
    public partial class HtmlParser
    {
        /// <summary>
        /// Takes the current position of the index on the table and return the index of where the comment ends
        /// </summary>
        /// <param name="index">Beginning location of the suspected comment</param>
        /// <returns></returns>
        private int SkipComment(int index)
        {
            do
            {
                if (_content[index].Equals('-'))
                    if (_content[index + 1].Equals('-'))
                        if (_content[index + 2].Equals('>'))
                            break;
                index++;
            } while (true);

            return index + 3; // OR + 2?
        }

        /// <summary>
        /// Returns the HtmlObject at the given index used for opening tags
        /// </summary>
        /// <param name="index">Beginning location of the Tag</param>
        /// <returns></returns>
        private Tuple<int, HtmlObject> GetOpeningTagName(int index)
        {
            HtmlObject htmlTag = new HtmlObject { Type = HtmlObjectType.OpeningTag };
            string OpeningTagName = "";

            while (!(_content[index].Equals('>') || _content[index].Equals(' ') || _content[index].Equals('/')))
            {
                OpeningTagName += _content[index].ToString();
                index++;
            }

            //if (Content[i].Equals('/'))//Self closing tag
            //    htmlTag.type = HtmlObjectType.SelfClosingTag;
            //Reduce i by one because for will increase it by one again skipping a character
            index--;
            htmlTag.Name = OpeningTagName;
            return new Tuple<int, HtmlObject>(index, htmlTag);
        }

        /// <summary>
        /// Returns the HtmlObject at the given index used for closing tags
        /// </summary>
        /// <param name="index">Beginning location of the Tag</param>
        /// <returns></returns>
        private Tuple<int, string> GetClosingTagName(int index)
        {
            HtmlObject htmlTag = new HtmlObject { Type = HtmlObjectType.ClosingTag };

            //string closingtagName = "";
            int beginningIndex = index;
            while (!(_content[index].Equals('>') || _content[index].Equals(' ')))
            {
                //closingtagName += _content[index];
                index++;
            }
            string temp = new string(_content, beginningIndex, index - beginningIndex);
            index--;
            return new Tuple<int, string>(index, temp);
        }

        private Tuple<int, HtmlObject> GetProperties(int index, int limit, HtmlObject htmlTag)
        {
            //string propertyName = "";
            //string propertyContent = "";
            int nameBeginning = index;
            while (index < limit && !_content[index].Equals('='))
            {
                //propertyName += this._content[index];
                index++;
            }
            int nameEnding = index - 1;

            while (index < limit && !_content[index].Equals('"'))
            {
                index++;
            }
            index++;

            int ContentBeginning = index;
            while (index < limit && !_content[index].Equals('"'))
            {
                //propertyContent += this._content[index];
                index++;
            }
            int ContentEnding = index - 1;

            while (index < limit && (!_content[index].Equals('>') && (_content[index].Equals(' ') || _content[index].Equals('/'))))
            {
                if (_content[index].Equals('/'))//Self closing tag
                    htmlTag.Type = HtmlObjectType.SelfClosingTag;
                index++;
            }

            try
            {
                string propertyName = new string(_content, nameBeginning, (nameEnding + 1) - nameBeginning);
                string propertyContent = new string(_content, ContentBeginning, (ContentEnding + 1) - ContentBeginning);
                htmlTag.Properties.Add(propertyName, propertyContent);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
            }

            index--;
            return new Tuple<int, HtmlObject>(index, htmlTag);
        }

        private Tuple<int, HtmlObject> GetInBetweenContentBAD(int index, int limit, HtmlObject htmlTag)
        {
            if (_content[index - 1].Equals('/'))//Not correct : it works if it is like this "/>" but what if spaces exist in-between like "/ >"
            {
                htmlTag.Type = HtmlObjectType.SelfClosingTag;
            }
            else
            {
                int beginning = index;
                //Skip the ">" sign
                index++;
                const string propertyName = "InBetweenContent";
                string propertyContent = "";

                bool exitFlag = false;

                while (!(_content[index].Equals('<') && _content[index + 1].Equals('/')) && !exitFlag)
                {
                    //propertyContent += this._content[index];
                    if (_content[index].Equals('<') && propertyContent.Trim().Equals("<"))
                    {
                        exitFlag = true;
                    }
                    else
                        index++;
                }
                index--;
                if (!exitFlag)
                {
                    Char[] temp = new char[index - beginning];
                    if (index - beginning > 0)
                    {
                        Array.Copy(_content, beginning + 1, temp, 0, index - beginning);
                        propertyContent = new string(temp);
                    }
                    else
                    {
                        propertyContent = "";
                    }
                    //propertyContent = new string(_content.CopyTo(_content,));
                    //propertyContent = new string(_content[new Range(new Index(beginning + 1, false), new Index(index + 1, false))]);
                    htmlTag.Properties.Add(propertyName, propertyContent);
                }
            }
            return new Tuple<int, HtmlObject>(index, htmlTag);
        }

        private Tuple<int, HtmlObject> GetInBetweenContent3(int index, int limit, HtmlObject htmlTag)
        {
            if (_content[index - 1].Equals('/'))//Not correct : it works if it is like this "/>" but what if spaces exist in-between like "/ >"
            {
                htmlTag.Type = HtmlObjectType.SelfClosingTag;
            }
            else
            {
                //Skip the ">" sign
                index++;
                const string propertyName = "InBetweenContent";
                string propertyContent = "";

                int beginning = index;
                bool exitFlag = false;
                while (!(_content[index].ToString() + _content[index + 1]).Equals("</") && !exitFlag)
                {
                    if (_content[index].Equals('<') && propertyContent.Trim().Equals("<"))
                    {
                        exitFlag = true;
                        break;
                    }
                    else
                        index++;
                }
                index--;
                if (!exitFlag)
                {
                    if (index - beginning > 0)
                    {
                        Char[] temp = new char[index - beginning];
                        //Array.Copy(_content, beginning + 1, temp, 0, index - beginning);
                        propertyContent = "new string(temp);";
                    }
                    else
                    {
                        propertyContent = "";
                    }
                    htmlTag.Properties.Add(propertyName, propertyContent);
                }
            }
            return new Tuple<int, HtmlObject>(index, htmlTag);
        }

        private Tuple<int, string> GetInBetweenContent(int index, int limit, HtmlObject htmlTag)
        {
            string propertyContent = "";
            if (_content[index - 1].Equals('/'))//Not correct : it works if it is like this "/>" but what if spaces exist in-between like "/ >"
            {
                htmlTag.Type = HtmlObjectType.SelfClosingTag;
            }
            else
            {
                index++;
                do
                {
                    char c = _content[index];

                    if (c.Equals('<'))
                    {
                        propertyContent = propertyContent.Trim().Replace("\r", string.Empty);
                        propertyContent = propertyContent.Trim().Replace("\n", string.Empty);
                        propertyContent = propertyContent.Replace(Environment.NewLine, string.Empty);
                        if (String.IsNullOrWhiteSpace(propertyContent))
                        {
                            break;
                        }

                        if (!_content[index - 1].Equals('\\'))
                        {
                            break;
                        }
                        if (_content[index + 1].Equals('/'))
                        {
                            if (htmlTag.Name.Equals("script"))//Scripts can contain whatever they almost want even other tags
                            {
                                int begin = index + 2;
                                char[] _name = htmlTag.Name.ToCharArray();
                                bool equals = true;
                                int j = 0;
                                for (j = begin; j < begin + htmlTag.Name.Length; j++)
                                {
                                    if (_content[j] != _name[j - begin])
                                    {
                                        equals = false;
                                        break;
                                    }
                                }
                                if (equals)//End of inBetweenContent reached
                                {
                                    //if (_content[j].Equals('>'))
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    propertyContent += _content[index];

                    index++;
                } while (true);

                index--;
            }
            return new Tuple<int, string>(index, propertyContent);
        }


        private Tuple<int, string> GetInBetweenContent(int index, int limit)
        {
            string propertyContent = "";
            index++;
            do
            {

                char c = _content[index];

                if (c.Equals('<'))
                {

                    propertyContent = propertyContent.Trim().Replace("\r", string.Empty);
                    propertyContent = propertyContent.Trim().Replace("\n", string.Empty);
                    propertyContent = propertyContent.Replace(Environment.NewLine, string.Empty);
                    if (String.IsNullOrWhiteSpace(propertyContent))
                    {
                        break;
                    }
                    if (_content[index + 1].Equals('/'))
                    {
                        break;
                    }
                    if (!_content[index - 1].Equals('\\'))
                    {
                        break;
                    }
                }

                propertyContent += _content[index];

                index++;
            } while (true);

            index--;
            return new Tuple<int, string>(index, propertyContent);
        }






        /// <summary>
        ///
        /// </summary>
        /// <param name="i"></param>
        /// <param name="HtmlObjectsList"></param>
        /// <param name="htmlTag"></param>
        /// <returns></returns>
        private int GetInBetweenContentParent(Webpage _webpage, HtmlObject htmlTag)
        {
            int index = _webpage.Count - 1;
            HtmlObject ho; //get last object
            int closingPoints = 0;
            int openingPoints = 0;

            do
            {
                if (index == 1365)
                {
                    int das = 22;
                }

                ho = _webpage[index];
                //Check if HtmlObject is of the same tag type
                if (ho.Name == htmlTag.Name)
                {
                    switch (ho.Type)
                    {
                        case HtmlObjectType.OpeningTag:
                            openingPoints++;
                            break;

                        case HtmlObjectType.ClosingTag:
                            closingPoints++;
                            break;

                        case HtmlObjectType.SelfClosingTag:
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                if ((openingPoints - closingPoints > 0 || index == 1))
                {
                    if (index == 1)
                    {
                        int dsadsa = 2;
                    }
                    return index + 1;
                }

                index--;
            } while (index >= 0);// && index < 100);

            return -1;
        }

        /// <summary>
        /// Get the occurrence of the last '>' closing tag (meaning the html file ends there)
        /// </summary>
        /// <returns></returns>
        private int GetEndOfFile()
        {
            int endOfFile = _content.Length - 1;
            for (int i = _content.Length - 1; i >= 0; i--)
            {
                if (_content[i].Equals('>'))
                {
                    endOfFile = i;
                    break;
                }
            }
            return endOfFile;
        }

        public Webpage Parse()
        {
            return Analyze();
        }
    }
}