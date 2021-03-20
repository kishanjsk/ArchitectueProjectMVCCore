namespace Architecture.Utility
{
    public static class URLUtilities
    {
        public static string GetFileName(string hrefLink)
        {
            string[] parts = hrefLink.Split('/');
            string fileName = "";

            if (parts.Length > 0)
                fileName = parts[parts.Length - 1];
            else
                fileName = hrefLink;

            return fileName;
        }
    }
}
