using HtmlWebParser.Entities;
using System.Collections.Generic;
using HtmlWebParser.Elements;
using HtmlWebParser.Elements.BlockElements;

namespace DynamicAPI
{
    public class Locator
    {
        public List<HtmlObject> PrecedingTags;      //Tags that exist before our Main Container Tag
        public HtmlObject MainContainer;            //The tag that Contains all the List Items
        public List<HtmlObject> Content;                  //The Contents of the Container
        public List<HtmlObject> FollowingTags;      //Tags that exist following our Main Container Tag

        public Locator(Webpage _webpage)
        {
            foreach (Element e in _webpage._elements)
            {
                if (e is Div div)
                {
                    if (div.id == "wpv-view-layout-262648")
                    {
                        int g = 2;
                    }
                }
            }
        }
    }
}