using HtmlWebParser.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlWebParser.Services
{
    public class HtmlParser
    {
        private readonly char[] Content;
        public HtmlParser(string Content)
        {
            Content.Replace(System.Environment.NewLine, "");
            this.Content = Content.ToCharArray();
        }
        private List<HtmlObject> Analyze()
        {
            List<HtmlObject> TagsList = new List<HtmlObject>();
            int depth = 0;//Represents depth in the tree of Tags
            //for is not probably needeed here an if should suffice

            for (int i = 0; i < Content.Length; i++)
            {
                //TODO : Escape text//comments
                if (Content[i].Equals('<'))
                {
                    i++;
                    HtmlObject tag = new HtmlObject();
                    tag.depth = depth;
                    //TODO: PROBABLY HAS SOME FALSE POSITIVES
                    //Check if what is following is a comment
                    if (this.Content[i].Equals('!') && (this.Content[i+1] == '-' && this.Content[i + 2] == '-'))
                    {
                        i += 2;//Skip the next two "--" characters
                        //We are in a comment OMG ESCAPE IMMEDIATELY
                        string key = "";
                        do
                        {
                            i++;
                            if (this.Content[i].Equals('-')
                                                || (this.Content[i].Equals('>') && key.Equals("--")))
                            {
                                key += this.Content[i];
                            }
                            else
                                key = "";
                        } while (key != "-->");
                        continue;
                    }
                    if (Content[i].Equals('/'))
                    {

                        //Closing Tag
                        tag.type = HtmlObjectType.ClosingTag;
                        depth--;
                        tag.depth = depth;
                        i++;    //Skip the '/' character
                    }
                    //else if (Content[i].Equals('\\'))
                    //{
                    //    //Opening Tag
                    //    tag.type = HtmlObjectType.OpeningTag;
                    //    depth++;
                    //}
                    Boolean inNameField = true; //Ignore properties variable, True when reading properties
                    do
                    {
                        if (this.Content[i].Equals(' '))
                        {
                            //Properties Ignore for now
                            inNameField = false;
                            i++;
                            continue;   //Skip and move to next character
                        }
                        if (inNameField)//If in the name field of a property
                            tag.Name += this.Content[i];
                        else
                        {
                            string propertyName = "";

                            do
                            {
                                propertyName += this.Content[i];
                                if (propertyName.Equals("height"))
                                {

                                }
                                i++;
                            } while (this.Content[i] != '=');   //Read the whole property name till =
                            i++; ///Skip the " character after the equals sign and start reading letters
                            i++;//Move to the property's content

                            //Check if the Content is empty ("")

                            string propertyContent = "";

                            if (this.Content[i] != '"')
                            {
                                do
                                {
                                    propertyContent += this.Content[i];
                                    i++;
                                } while (this.Content[i] != '"');
                            }

                            tag.Properties.Add(propertyName, propertyContent);
                        }

                        i++;
                    } while (this.Content[i] != '>');
                    TagsList.Add(tag);

                    //If the tag to be added is a closing tag, the previous one should be an opening of the same type.
                    //if it is not the it is either a Singleton Tag or an Html mistake
                    if (SingletonTags.isSingleton(tag))
                    {
                        depth--;
                    }
                }
                else
                {
                    /* INCREASING BUFFER SIZE WILL IMPROVE PERFORMANCE */
                    const int tableLength = 100;//Length of the "buffer" table
                    int index = 0;  //Just an Index for the iteration
                    int currentItemIndex = TagsList.Count - 1;
                    string tempContent = TagsList[currentItemIndex].Content;   //Temporary variable for the content
                    char[] tempString = new char[tableLength];
                    while (i < Content.Length && !this.Content[i].Equals('<'))
                    {
                        if (index == tempString.Length)
                        {
                            index = 0;
                            tempContent += new string(tempString);
                            tempString = new char[tableLength];
                        }
                        tempString[index++] = this.Content[i];
                        i++;
                    }
                    string s = new string(tempString);
                    tempContent += s.Remove(index, s.Length - index);
                    TagsList[currentItemIndex].Content = tempContent;
                    i--;
                }
            }
            return TagsList;
        }

        public List<HtmlObject> Result()
        {
            return Analyze();
        }
    }
}
