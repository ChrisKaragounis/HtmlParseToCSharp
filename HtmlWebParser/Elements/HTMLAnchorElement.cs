using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements
{
    class HTMLAnchorElement : HTMLElement
    {
        public HTMLAnchorElement(HtmlObject obj) : base(obj)
        {
        }

        public string href;

    }
}
