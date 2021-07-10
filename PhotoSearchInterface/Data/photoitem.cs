namespace PhotoSearchInterface
{
    /// <summary>
    ///     Class to get information from Json response
    /// </summary>
    public class PhotoItem
    {
        /// <summary>
        ///     Field to store url from response
        /// </summary>
        public media media { get; set; }

        /// <summary>
        ///     Field to store title from response
        /// </summary>
        public string title { get; set; }
    }
}