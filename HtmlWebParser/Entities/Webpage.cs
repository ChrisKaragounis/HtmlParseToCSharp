using HtmlWebParser.Elements;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HtmlWebParser.Entities
{
    public class Webpage : IEnumerable

    {
        private List<HtmlObject> _htmlObjectsList;
        private List<Element> _elements;

        private uint _depth = 0;

        public Webpage()
        {
            this._htmlObjectsList = new List<HtmlObject>(200);
            _elements = new List<Element>();
        }

        public HtmlObject this[int index]
        {
            get => _htmlObjectsList[index];
        }

        public int Count => _htmlObjectsList.Count;
        IEnumerator IEnumerable.GetEnumerator() => _htmlObjectsList.GetEnumerator();

        internal void Add(HtmlObject obj)
        {
            obj.Depth = obj.Type switch
            {
                HtmlObjectType.OpeningTag => _depth++,
                HtmlObjectType.ClosingTag => --_depth,
                HtmlObjectType.SelfClosingTag => _depth,
                _ => throw new ArgumentOutOfRangeException()
            };

            Element e = obj.ToElement();
            if (e != null)
            {
                _elements.Add(e);
            }
            this._htmlObjectsList.Add(obj);
        }

        internal HtmlObject Get(int i)
        {
            return _htmlObjectsList[i];
        }

    }
}