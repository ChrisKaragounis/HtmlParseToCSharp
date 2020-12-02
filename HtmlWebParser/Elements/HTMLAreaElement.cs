using System;
using System.Collections.Generic;
using System.Text;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements
{
    public abstract class HTMLAreaElement : HTMLElement
    {
        //public HTMLAreaElement(HtmlObject obj) : base(obj)
        //{
        //}
        /// <summary>
        /// Is a DOMString that reflects the alt HTML attribute, containing alternative text for the element.
        /// </summary>
        public string alt;

        /// <summary>
        /// Is a DOMString that reflects the coords HTML attribute, containing coordinates to define the hot-spot region.
        /// </summary>
        public string coords;

        /// <summary>
        /// Is a DOMString indicating that the linked resource is intended to be downloaded rather than displayed in the browser. The value represent the proposed name of the file. If the name is not a valid filename of the underlying OS, browser will adapt it.
        /// </summary>
        public string download;
        /// <summary>
        /// Is a Boolean flag indicating if the area is inactive (true) or active (false).
        /// </summary>
        public string noHref;
        /// <summary>
        /// Is a DOMString that reflects the rel HTML attribute, indicating relationships of the current document to the linked resource.
        /// </summary>
        public string rel;
        /// <summary>
        /// Is a DOMString that reflects the shape HTML attribute, indicating the shape of the hot-spot, limited to known values.
        /// </summary>
        public string shape;
        /// <summary>
        /// Is a DOMString that reflects the target HTML attribute, indicating the browsing context in which to open the linked resource.
        /// </summary>
        public string target;
        protected HTMLAreaElement(HtmlObject obj) : base(obj)
        {
        }
        //public string toString()
        //{
        //    return href.ToString();
        //}
    }
}
