using HtmlWebParser.Entities;

namespace HtmlWebParser.Elements
{
    internal class HTMLImageElement : HTMLElement
    {
        /// <summary>
        /// A DOMString that reflects the alt HTML attribute, thus indicating the alternate fallback content to be displayed if the image has not been loaded.
        /// </summary>
        public string alt;

        /// <summary>
        /// Returns a Boolean that is true if the browser has finished fetching the image, whether successful or not. That means this value is also true if the image has no src value indicating an image to load.
        /// </summary>
        public readonly string complete;

        /// <summary>
        /// A DOMString specifying the CORS setting for this image element. See CORS settings attributes for further details. This may be null if CORS is not used.
        /// </summary>
        public string crossOrigin;

        /// <summary>
        /// Returns a USVString representing the URL from which the currently displayed image was loaded. This may change as the image is adjusted due to changing conditions, as directed by any media queries which are in place.
        /// </summary>
        public readonly string currentSrc;

        /// <summary>
        /// An optional DOMString representing a hint given to the browser on how it should decode the image. If this value is provided, it must be one of the possible permitted values: sync to decode the image synchronously, async to decode it asynchronously, or auto to indicate no preference (which is the default). Read the decoding page for details on the implications of this property's values.
        /// </summary>
        public string decoding;

        /// <summary>
        /// An integer value that reflects the height HTML attribute, indicating the rendered height of the image in CSS pixels
        /// </summary>
        public string height;

        /// <summary>
        /// A Boolean that reflects the ismap HTML attribute, indicating that the image is part of a server-side image map. This is different from a client-side image map, specified using an <img> element and a corresponding <map> which contains <area> elements indicating the clickable areas in the image. The image must be contained within an <a> element; see the ismap page for details.
        /// </summary>
        public string isMap;

        /// <summary>
        /// A DOMString providing a hint to the browser used to optimize loading the document by determining whether to load the image immediately (eager) or on an as-needed basis (lazy).
        /// </summary>
        public string loading;

        /// <summary>
        /// Returns an integer value representing the intrinsic height of the image in CSS pixels, if it is available; else, it shows 0. This is the height the image would be if it were rendered at its natural full size.
        /// </summary>
        public readonly string naturalHeight;

        /// <summary>
        /// An integer value representing the intrinsic width of the image in CSS pixels, if it is available; otherwise, it will show 0. This is the width the image would be if it were rendered at its natural full size.
        /// </summary>
        public readonly string naturalWidth;

        /// <summary>
        /// A DOMString that reflects the referrerpolicy HTML attribute, which tells the user agent how to decide which referrer to use in order to fetch the image. Read this article for details on the possible values of this string.
        /// </summary>
        public string referrerPolicy;

        /// <summary>
        /// A DOMString reflecting the sizes HTML attribute. This string specifies a list of comma-separated conditional sizes for the image; that is, for a given viewport size, a particular image size is to be used. Read the documentation on the sizes page for details on the format of this string.
        /// </summary>
        public string sizes;

        /// <summary>
        /// A USVString that reflects the src HTML attribute, which contains the full URL of the image including base URI. You can load a different image into the element by changing the URL in the src attribute.
        /// </summary>
        public string src;

        /// <summary>
        /// A USVString reflecting the srcset HTML attribute. This specifies a list of candidate images, separated by commas (',', U+002C COMMA). Each candidate image is a URL followed by a space, followed by a specially-formatted string indicating the size of the image. The size may be specified either the width or a size multiple. Read the srcset page for specifics on the format of the size substring.
        /// </summary>
        public string srcset;

        /// <summary>
        /// A DOMString reflecting the usemap HTML attribute, containing the page-local URL of the <map> element describing the image map to use. The page-local URL is a pound (hash) symbol (#) followed by the ID of the <map> element, such as #my-map-element. The <map> in turn contains <area> elements indicating the clickable areas in the image.
        /// </summary>
        public string useMap;

        /// <summary>
        /// An integer value that reflects the width HTML attribute, indicating the rendered width of the image in CSS pixels.
        /// </summary>
        public string width;

        /// <summary>
        /// An integer indicating the horizontal offset of the left border edge of the image's CSS layout box relative to the origin of the <html> element's containing block.
        /// </summary>
        public readonly string x;

        /// <summary>
        ///The integer vertical offset of the top border edge of the image's CSS layout box relative to the origin of the <html> element's containing block.
        /// </summary>
        public readonly string y;

        public HTMLImageElement(HtmlObject obj) : base(obj)
        {
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key.Trim())
                {
                    case "alt":
                        alt = value;
                        break;

                    case "complete":
                        complete = value;
                        break;

                    case "crossOrigin":
                        crossOrigin = value;
                        break;

                    case "currentSrc":
                        currentSrc = value;
                        break;

                    case "decoding":
                        decoding = value;
                        break;

                    case "height":
                        height = value;
                        break;

                    case "isMap":
                        isMap = value;
                        break;

                    case "loading":
                        loading = value;
                        break;

                    case "naturalHeight":
                        naturalHeight = value;
                        break;

                    case "naturalWidth":
                        naturalWidth = value;
                        break;

                    case "referrerPolicy":
                        referrerPolicy = value;
                        break;

                    case "sizes":
                        sizes = value;
                        break;

                    case "src":
                        src = value;
                        break;

                    case "srcset":
                        srcset = value;
                        break;

                    case "useMap":
                        useMap = value;
                        break;

                    case "width":
                        width = value;
                        break;

                    case "x":
                        x = value;
                        break;

                    case "y":
                        y = value;
                        break;
                }
            }
        }
    }
}