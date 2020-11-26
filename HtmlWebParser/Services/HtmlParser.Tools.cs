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
            string temporaryString = "";
            const string exitKey = "-->";
            //TODO: probably crashes if comment at the of html file cause overflow
            do
            {
                temporaryString = _content[index + 1].ToString() + _content[index + 2] + _content[index + 3];
                index++;
            } while (!temporaryString.Equals(exitKey));
            index += 2;

            return index;
        }

        /// <summary>
        /// Returns the HtmlObject at the given index used for opening tags
        /// </summary>
        /// <param name="index">Beginning location of the Tag</param>
        /// <returns></returns>
        private Tuple<int, HtmlObject> GetOpeningTagName(int index)
        {
            HtmlObject htmlTag = new HtmlObject { type = HtmlObjectType.OpeningTag };
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
        private Tuple<int, HtmlObject> GetClosingTagName(int index)
        {
            HtmlObject htmlTag = new HtmlObject { type = HtmlObjectType.ClosingTag };

            string ClosingtagName = "";
            while (!(_content[index].Equals('>') || _content[index].Equals(' ')))
            {
                ClosingtagName += _content[index];
                index++;
            }
            index--;
            htmlTag.Name = ClosingtagName;
            return new Tuple<int, HtmlObject>(index, htmlTag);
        }

        private Tuple<int, HtmlObject> GetProperties(int index, int limit, HtmlObject htmlTag)
        {
            string propertyName = "";
            string propertyContent = "";

            while (index < limit && !_content[index].Equals('='))
            {
                propertyName += this._content[index];
                index++;
            }
            while (index < limit && !_content[index].Equals('"'))
            {
                index++;
            }
            index++;
            while (index < limit && !_content[index].Equals('"'))
            {
                propertyContent += this._content[index];
                index++;
            }
            while (index < limit && (!_content[index].Equals('>') && (_content[index].Equals(' ') || _content[index].Equals('/'))))
            {
                if (_content[index].Equals('/'))//Self closing tag
                    htmlTag.type = HtmlObjectType.SelfClosingTag;
                index++;
            }
            htmlTag.Properties.Add(propertyName, propertyContent + '"');
            index--;
            return new Tuple<int, HtmlObject>(index, htmlTag);
        }

        private Tuple<int, HtmlObject> GetInBetweenContent(int index, int limit, HtmlObject htmlTag)
        {
            if (_content[index - 1].Equals('/'))//Not correct : it works if it is like this "/>" but what if spaces exist in-between like "/ >"
            {
                htmlTag.type = HtmlObjectType.SelfClosingTag;
            }
            else
            {
                //Skip the ">" sign
                index++;
                const string propertyName = "InBetweenContent";
                string propertyContent = "";

                bool exitFlag = false;
                while (!(_content[index].ToString() + _content[index + 1]).Equals("</") && !exitFlag)
                {
                    propertyContent += this._content[index];
                    if (_content[index].Equals('<') && propertyContent.Trim().Equals("<"))
                    {
                        exitFlag = true;
                    }
                    else
                        index++;
                }
                index--;
                if (!exitFlag)
                    htmlTag.Properties.Add(propertyName, propertyContent);
            }
            return new Tuple<int, HtmlObject>(index, htmlTag);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="i"></param>
        /// <param name="HtmlObjectsList"></param>
        /// <param name="htmlTag"></param>
        /// <returns></returns>
        private int GetInBetweenContentParent(IReadOnlyList<HtmlObject> HtmlObjectsList, HtmlObject htmlTag)
        {
            int index = HtmlObjectsList.Count - 1;
            HtmlObject ho; //get last object
            int closingPoints = 0;
            int openingPoints = 0;
            do
            {
                ho = HtmlObjectsList[index];
                //Check if HtmlObject is of the same tag type
                if (ho.Name != htmlTag.Name)
                {
                    switch (ho.type)
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

        public List<HtmlObject> Parse()
        {
            return Analyze();
        }
    }
}