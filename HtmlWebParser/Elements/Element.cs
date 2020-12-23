using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements
{
    public abstract class Element : GlobalAttributes
    {
        public string TagName { get; set; }
        public uint Depth;

        public Element(HtmlObject obj)
        {
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key.Trim())
                {
                    case "class":
                        @class = value;
                        break;

                    case "is":
                        @is = value;
                        break;

                    case "accesskey":
                        accesskey = value;
                        break;

                    case "autocapitalize":
                        autocapitalize = value;
                        break;

                    case "contenteditable":
                        contenteditable = value;
                        break;

                    case "contextmenu":
                        contextmenu = value;
                        break;

                    case "data":
                        data = value;
                        break;

                    case "dir":
                        dir = value;
                        break;

                    case "draggable":
                        draggable = value;
                        break;

                    case "dropzone":
                        dropzone = value;
                        break;

                    case "exportparts":
                        exportparts = value;
                        break;

                    case "hidden":
                        hidden = value;
                        break;

                    case "id":
                        id = value;
                        break;

                    case "inputmode":
                        inputmode = value;
                        break;

                    case "itemid":
                        itemid = value;
                        break;

                    case "itemprop":
                        itemprop = value;
                        break;

                    case "itemref":
                        itemref = value;
                        break;

                    case "itemscope":
                        itemscope = value;
                        break;

                    case "itemtype":
                        itemtype = value;
                        break;

                    case "lang":
                        lang = value;
                        break;

                    case "part":
                        part = value;
                        break;

                    case "slot":
                        slot = value;
                        break;

                    case "spellcheck":
                        spellcheck = value;
                        break;

                    case "style":
                        style = value;
                        break;

                    case "tabindex":
                        tabindex = value;
                        break;

                    case "title":
                        title = value;
                        break;

                    case "translate":
                        translate = value;
                        break;
                }
            }
        }

        public override string ToString()
        {
            return TagName;
        }

        /// <summary>
        /// A space-separated list of the classes of the element. Classes allows CSS and JavaScript to select and access specific elements via the class selectors or functions like the method Document.getElementsByClassName().
        /// </summary>
        public string @class { get; set; }

        /// <summary>
        /// Allows you to specify that a standard HTML element should behave like a registered custom built-in element (see Using custom elements for more details).
        /// </summary>
        public string @is { get; set; }

        /// <summary>
        /// Provides a hint for generating a keyboard shortcut for the current element. This attribute consists of a space-separated list of characters. The browser should use the first one that exists on the computer keyboard layout.
        /// </summary>
        public string accesskey { get; set; }

        ///<summary>Controls whether and how text input is automatically capitalized as it is entered/edited by the user. It can have the following values:
        ///<value>off or none</value>
        ///no autocapitalization is applied (all letters default to lowercase)
        ///on or sentences, the first letter of each sentence defaults to a capital letter; all other letters default to lowercase
        ///words, the first letter of each word defaults to a capital letter; all other letters default to lowercase
        ///characters, all letters should default to uppercase
        /// </summary>
        public string autocapitalize { get; set; }

        /// <summary>
        /// An enumerated attribute indicating if the element should be editable by the user. If so, the browser modifies its widget to allow editing. The attribute must take one of the following values:
        /// true or the empty string, which indicates that the element must be editable;
        /// false, which indicates that the element must not be editable.
        /// </summary>
        public string contenteditable { get; set; }

        /// <summary>
        /// The id of a <menu> to use as the contextual menu for this element.
        /// </summary>
        public string contextmenu { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// Forms a class of attributes, called custom data attributes, that allow proprietary information to be exchanged between the HTML and its DOM representation that may be used by scripts. All such custom data are available via the HTMLElement interface of the element the attribute is set on. The HTMLElement.dataset property gives access to them.
        public string data { get; set; }

        /// <summary>
        /// An enumerated attribute indicating the directionality of the element's text. It can have the following values:
        ///ltr, which means left to right and is to be used for languages that are written from the left to the right(like English);
        ///rtl, which means right to left and is to be used for languages that are written from the right to the left(like Arabic);
        ///auto, which lets the user agent decide.It uses a basic algorithm as it parses the characters inside the element until it finds a character with a strong directionality, then it applies that directionality to the whole element.
        /// </summary>
        public string dir { get; set; }

        /// <summary>
        /// An enumerated attribute indicating whether the element can be dragged, using the Drag and Drop API. It can have the following values:
        ///true, which indicates that the element may be dragged
        ///false, which indicates that the element may not be dragged.
        /// </summary>
        public string draggable { get; set; }

        /// <summary>
        /// An enumerated attribute indicating what types of content can be dropped on an element, using the Drag and Drop API. It can have the following values:
        ///copy, which indicates that dropping will create a copy of the element that was dragged
        ///move, which indicates that the element that was dragged will be moved to this new location.
        ///    link, will create a link to the dragged data.
        /// </summary>
        public string dropzone { get; set; }

        /// <summary>
        /// Used to transitively export shadow parts from a nested shadow tree into a containing light tree.
        /// </summary>
        public string exportparts { get; set; }

        /// <summary>
        /// A Boolean attribute indicates that the element is not yet, or is no longer, relevant. For example, it can be used to hide elements of the page that can't be used until the login process has been completed. The browser won't render such elements. This attribute must not be used to hide content that could legitimately be shown.
        /// </summary>
        public string hidden { get; set; }

        /// <summary>
        /// Defines a unique identifier (ID) which must be unique in the whole document. Its purpose is to identify the element when linking (using a fragment identifier), scripting, or styling (with CSS).
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Provides a hint to browsers as to the type of virtual keyboard configuration to use when editing this element or its contents. Used primarily on <input> elements, but is usable on any element while in contenteditable mode.
        /// </summary>
        public string inputmode { get; set; }

        /// <summary>
        /// The unique, global identifier of an item.
        /// </summary>
        public string itemid { get; set; }

        /// <summary>
        /// Used to add properties to an item. Every HTML element may have an itemprop attribute specified, where an itemprop consists of a name and value pair.
        /// </summary>
        public string itemprop { get; set; }

        /// <summary>
        /// Properties that are not descendants of an element with the itemscope attribute can be associated with the item using an itemref. It provides a list of element ids (not itemids) with additional properties elsewhere in the document.
        /// </summary>
        public string itemref { get; set; }

        /// <summary>
        /// itemscope (usually) works along with itemtype to specify that the HTML contained in a block is about a particular item. itemscope creates the Item and defines the scope of the itemtype associated with it. itemtype is a valid URL of a vocabulary (such as schema.org) that describes the item and its properties context.
        /// </summary>
        public string itemscope { get; set; }

        /// <summary>
        /// Specifies the URL of the vocabulary that will be used to define itemprops (item properties) in the data structure. itemscope is used to set the scope of where in the data structure the vocabulary set by itemtype will be active.
        /// </summary>
        public string itemtype { get; set; }

        /// <summary>
        /// Helps define the language of an element: the language that non-editable elements are in, or the language that editable elements should be written in by the user. The attribute contains one “language tag” (made of hyphen-separated “language subtags”) in the format defined in Tags for Identifying Languages (BCP47). xml:lang has priority over it.
        /// </summary>
        public string lang { get; set; }

        /// <summary>
        /// A space-separated list of the part names of the element. Part names allows CSS to select and style specific elements in a shadow tree via the ::part pseudo-element.
        /// </summary>
        public string part { get; set; }

        /// <summary>
        /// Assigns a slot in a shadow DOM shadow tree to an element: An element with a slot attribute is assigned to the slot created by the <slot> element whose name attribute's value matches that slot attribute's value.
        /// </summary>
        public string slot { get; set; }

        /// <summary>
        /// An enumerated attribute defines whether the element may be checked for spelling errors. It may have the following values:
        ///true, which indicates that the element should be, if possible, checked for spelling errors;
        ///    false, which indicates that the element should not be checked for spelling errors.
        /// </summary>
        public string spellcheck { get; set; }

        /// <summary>
        /// Contains CSS styling declarations to be applied to the element. Note that it is recommended for styles to be defined in a separate file or files. This attribute and the <style> element have mainly the purpose of allowing for quick styling, for example for testing purposes.
        /// </summary>
        public string style { get; set; }

        /// <summary>
        /// An integer attribute indicating if the element can take input focus (is focusable), if it should participate to sequential keyboard navigation, and if so, at what position. It can take several values:
        ///a negative value means that the element should be focusable, but should not be reachable via sequential keyboard navigation;
        ///     0 means that the element should be focusable and reachable via sequential keyboard navigation, but its relative order is defined by the platform convention;
        /// a positive value means that the element should be focusable and reachable via sequential keyboard navigation; the order in which the elements are focused is the increasing value of the tabindex.If several elements share the same tabindex, their relative order follows their relative positions in the document.
        /// </summary>
        public string tabindex { get; set; }

        /// <summary>
        /// Contains a text representing advisory information related to the element it belongs to. Such information can typically, but not necessarily, be presented to the user as a tooltip.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// An enumerated attribute that is used to specify whether an element's attribute values and the values of its Text node children are to be translated when the page is localized, or whether to leave them unchanged. It can have the following values:
        ///empty string and yes, which indicates that the element will be translated.
        ///  no, which indicates that the element will not be translated.
        /// </summary>
        public string translate { get; set; }

        public string onabort { get; set; }
        public string onautocomplete { get; set; }
        public string onautocompleteerror { get; set; }
        public string onblur { get; set; }
        public string oncancel { get; set; }
        public string oncanplay { get; set; }
        public string oncanplaythrough { get; set; }
        public string onchange { get; set; }
        public string onclick { get; set; }
        public string onclose { get; set; }
        public string oncontextmenu { get; set; }
        public string oncuechange { get; set; }
        public string ondblclick { get; set; }
        public string ondrag { get; set; }
        public string ondragend { get; set; }
        public string ondragenter { get; set; }
        public string ondragexit { get; set; }
        public string ondragleave { get; set; }
        public string ondragover { get; set; }
        public string ondragstart { get; set; }
        public string ondrop { get; set; }
        public string ondurationchange { get; set; }
        public string onemptied { get; set; }
        public string onended { get; set; }
        public string onerror { get; set; }
        public string onfocus { get; set; }
        public string oninput { get; set; }
        public string oninvalid { get; set; }
        public string onkeydown { get; set; }
        public string onkeypress { get; set; }
        public string onkeyup { get; set; }
        public string onload { get; set; }
        public string onloadeddata { get; set; }
        public string onloadedmetadata { get; set; }
        public string onloadstart { get; set; }
        public string onmousedown { get; set; }
        public string onmouseenter { get; set; }
        public string onmouseleave { get; set; }
        public string onmousemove { get; set; }
        public string onmouseout { get; set; }
        public string onmouseover { get; set; }
        public string onmouseup { get; set; }
        public string onmousewheel { get; set; }
        public string onpause { get; set; }
        public string onplay { get; set; }
        public string onplaying { get; set; }
        public string onprogress { get; set; }
        public string onratechange { get; set; }
        public string onreset { get; set; }
        public string onresize { get; set; }
        public string onscroll { get; set; }
        public string onseeked { get; set; }
        public string onseeking { get; set; }
        public string onselect { get; set; }
        public string onshow { get; set; }
        public string onsort { get; set; }
        public string onstalled { get; set; }
        public string onsubmit { get; set; }
        public string onsuspend { get; set; }
        public string ontimeupdate { get; set; }
        public string ontoggle { get; set; }
        public string onvolumechange { get; set; }
        public string onwaiting { get; set; }
    }
}