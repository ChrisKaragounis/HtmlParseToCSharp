using HtmlWebParser.Entities;
using System.ComponentModel.DataAnnotations;

namespace HtmlWebParser.Elements.InlineElements
{
    internal class IMG : HTMLImageElement
    {
        public new readonly string TagName = "img";

        /// <summary>
        /// Defines an alternative text description of the image.
        /// </summary>
        public string alt;

        /// <summary>
        /// Indicates if the fetching of the image must be done using a CORS request. Image data from a CORS-enabled image returned from a CORS request can be reused in the <canvas> element without being marked "tainted".
        /// </summary>
        public string crossorigin;

        /// <summary>
        /// Provides an image decoding hint to the browser.
        /// </summary>
        public string decoding;

        /// <summary>
        /// The intrinsic height of the image, in pixels. Must be an integer without a unit.
        /// </summary>
        public string height;

        /// <summary>
        /// This attribute tells the browser to ignore the actual intrinsic size of the image and pretend it’s the size specified in the attribute. Specifically, the image would raster at these dimensions and naturalWidth/naturalHeight on images would return the values specified in this attribute.
        /// </summary>
        public string intrinsicsize;

        /// <summary>
        /// This Boolean attribute indicates that the image is part of a server-side map. If so, the coordinates where the user clicked on the image are sent to the server.
        /// </summary>
        public string ismap;

        /// <summary>
        /// Indicates how the browser should load the image:
        /// </summary>
        public string loading;

        /// <summary>
        /// A string indicating which referrer to use when fetching the resource.
        /// </summary>
        public string referrerpolicy;

        /// <summary>
        /// One or more strings separated by commas, indicating a set of source sizes.
        /// </summary>
        public string sizes;

        /// <summary>
        /// The image URL. Mandatory for the <img> element. On browsers supporting srcset, src is treated like a candidate image with a pixel density descriptor 1x, unless an image with this pixel density descriptor is already defined in srcset, or unless srcset contains w descriptors.
        /// </summary>
        public string src;

        /// <summary>
        /// One or more strings separated by commas, indicating possible image sources for the user agent to use.
        /// </summary>
        public string srcset;

        /// <summary>
        /// The intrinsic width of the image in pixels. Must be an integer without a unit.
        /// </summary>
        public string width;

        /// <summary>
        /// The partial URL (starting with #) of an image map associated with the element.
        /// </summary>
        public string usemap;

        public IMG(HtmlObject obj) : base(obj)
        {
            if (!obj.Name.Equals(this.TagName))
                throw new ValidationException();
            foreach ((string key, string value) in obj.Properties)
            {
                switch (key.Trim())
                {
                    case "alt":
                        alt = value;
                        break;

                    case "crossorigin":
                        crossorigin = value;
                        break;

                    case "decoding":
                        decoding = value;
                        break;

                    case "height":
                        height = value;
                        break;

                    case "intrinsicsize":
                        intrinsicsize = value;
                        break;

                    case "ismap":
                        ismap = value;
                        break;

                    case "loading":
                        loading = value;
                        break;

                    case "referrerpolicy":
                        referrerpolicy = value;
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

                    case "width":
                        width = value;
                        break;

                    case "usemap":
                        usemap = value;
                        break;
                }
            }
        }
    }
}