namespace Kemet.ERP.Domain.Common.Utilities
{
    public static class IOHelper
    {
        private static readonly string RootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private static readonly string UploadPath = Path.Combine(RootPath, "uploads");

        public static string GetUserProfilePath(string? company = "common")
            => Path.Combine(UploadPath, company, "users", "profiles");

        public static string GetUserUploadPath(string? company = "common")
            => Path.Combine(UploadPath, company, "users", "uploads");

        public static string GetCompanyProfilePath(string? company = "common")
            => Path.Combine(UploadPath, company, "company", "profiles");





        public static string GenerateUniqueFileName(string fileNameWithExtension)
            => Path.GetFileNameWithoutExtension(fileNameWithExtension).Replace(" ", "_") +
               DateTime.Now.ToFileTimeUtc().ToString() +
               Path.GetExtension(fileNameWithExtension);

        public static string GetFullURL(string fullPath)
        {
            string? apiURL = ConfigurationHelper.GetURL("API");

            Uri fileUri = new Uri(fullPath);

            string fileUrl = fileUri.AbsoluteUri;

            fileUrl = fileUrl.Substring(fileUrl.IndexOf("wwwroot")).Replace("wwwroot", apiURL);

            return fileUrl;
        }

        public static void CheckOrCreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
        }


    }
}
