using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.Special
{
    class Head : Element
    {
        public new readonly string TagName = "head";

        /// <summary>
        ///The URIs of one or more metadata profiles, separated by white space.
        /// </summary>
        public string profile;

        public Head(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key.Trim())
                {
                    case "profile":
                        profile = value;
                        break;
                }
            }
        }
    }
}
