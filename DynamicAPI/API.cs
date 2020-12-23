using System;
using System.Collections.Generic;
using System.Text;
using HtmlWebParser.Entities;

namespace DynamicAPI
{
    public class API
    {
        private Webpage webpage;
        private Locator locator;
        public API(Webpage _webpage)
        {
            this.webpage = _webpage;
            Locator Locator = new Locator(_webpage);
        }
    }
}
