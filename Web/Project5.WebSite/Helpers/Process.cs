
namespace Project5.WebSite.Helpers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Web;

    public class ProcessHelper
    {
        private string ImagePath = HttpRuntime.AppDomainAppPath + "{0}.jpg";

        public ProcessHelper()
        {
        }

        public static ProcessHelper Instance { get { return getInstance(); } }
        private static ProcessHelper _instance { get; set; }

        private static ProcessHelper getInstance()
        {
            if(_instance == null)
            {
                _instance = new ProcessHelper();
            }

            return _instance;
        }

        public List<string> GetImagesPathsForOffer(int imgName)
        {
            List<string> images = new List<string>();

            string path = string.Format(ImagePath, imgName);
            if (File.Exists(path))
            {
                images.Add(path);
            }

            return images;
        }
    }
}