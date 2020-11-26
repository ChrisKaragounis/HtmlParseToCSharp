using HtmlWebParser.Entities;
using System.Collections.Generic;

namespace DynamicAPI
{
    public class Locator
    {
        public List<HtmlObject> PrecedingTags;      //Tags that exist before our Main Container Tag
        public HtmlObject MainContainer;            //The tag that Contains all the List Items
        public List<HtmlObject> Content;                  //The Contents of the Container
        public List<HtmlObject> FollowingTags;      //Tags that exist following our Main Container Tag

        public Locator(List<HtmlObject> PrecedingTags)
        {
        }
    }
}