using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HtmlWebParser.Elements.WebAPIs;
using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements.BlockElements
{
    class LI : HTMLLIElement
    {
        public new readonly string TagName = "li";

        /// <summary>
        /// This character attribute indicates the numbering type:
        /// a: lowercase letters
        /// A: uppercase letters
        /// i: lowercase Roman numerals
        /// I: uppercase Roman numerals
        /// 1: numbers
        /// </summary>
        public string type;
        /// <summary>
        /// This integer attribute indicates the current ordinal value of the list item as defined by the <ol> element. The only allowed value for this attribute is a number, even if the list is displayed with Roman numerals or letters. List items that follow this one continue numbering from the value set. The value attribute has no meaning for unordered lists (<ul>) or for menus (<menu>).
        /// </summary>
        public string value;
        public LI(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key)
                {
                    case "type":
                        type = value;
                        break;
                    case "value":
                        this.value = value;
                        break;
                }
            }
        }
    }
}
