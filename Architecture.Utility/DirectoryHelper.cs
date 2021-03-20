using System.IO;

namespace Architecture.Utility
{
    public class DirectoryHelper
    {
        /// <summary>
        /// create the directory if the not exist
        /// </summary>
        /// <param name="filePath">the path to create directory.</param>
        /// <returns></returns>
        public static string CreateDirectoty(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            return filePath;
        }
    }
}
