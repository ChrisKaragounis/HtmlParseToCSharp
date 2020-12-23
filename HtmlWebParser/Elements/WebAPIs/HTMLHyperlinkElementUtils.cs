namespace HtmlWebParser.Elements
{
    internal interface HTMLHyperlinkElementUtils
    {
        /// <summary>
        /// This a stringifier property that returns a USVString containing the whole URL, and allows the href to be updated.
        /// </summary>
        public string href { get; set; }

        /// <summary>
        /// This is a USVString containing the protocol scheme of the URL, including the final ':'.
        /// </summary>
        public string protocol { get; set; }

        /// <summary>
        /// This is a USVString containing the host, that is the hostname, and then, if the port of the URL is not empty (which can happen because it was not specified or because it was specified to be the default port of the URL's scheme), a ':', and the port of the URL.
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// This is a USVString containing the domain of the URL.
        /// </summary>
        public string hostname { get; set; }

        /// <summary>
        /// This is a USVString containing the port number of the URL.
        /// </summary>
        public string port { get; set; }

        /// <summary>
        /// Is a USVString containing an initial '/' followed by the path of the URL, not including the query string or fragment.
        /// </summary>
        public string pathname { get; set; }

        /// <summary>
        /// This is a USVString containing a '?' followed by the parameters of the URL.
        /// </summary>
        public string search { get; set; }

        /// <summary>
        /// This is a USVString containing a '#' followed by the fragment identifier of the URL.
        /// </summary>
        public string hash { get; set; }

        /// <summary>
        /// This is a USVString containing the username specified before the domain name.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// This is a USVString containing the password specified before the domain name.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// This returns a USVString containing the origin of the URL (that is its scheme, its domain and its port).
        /// </summary>
        public string origin { get; set; }

        /// <summary>
        /// This returns a USVString containing the whole URL. It is a synonym for HTMLHyperlinkElementUtils.href, though it can't be used to modify the value.
        /// Not to be confused with c# ToString method
        /// </summary>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public string toString()
        {
            return href.ToString();
        }
    }
}