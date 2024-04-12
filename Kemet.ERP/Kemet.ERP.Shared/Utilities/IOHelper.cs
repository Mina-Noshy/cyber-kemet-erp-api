namespace Kemet.ERP.Shared.Utilities
{
    public static class IOHelper
    {
        private readonly static string ROOT_FOLDER_PATH = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private readonly static string UPLOAD_FOLDER_PATH = Path.Combine(ROOT_FOLDER_PATH, "uploads");


        // Folder names.
        public static string USERS_PROFILES_FOLDER_PATH(long? companyId = null) => Path.Combine(UPLOAD_FOLDER_PATH, "users", "profiles", FormatCompanyInfo(companyId));
        public static string USERS_UPLOADS_FOLDER_PATH(long? companyId = null) => Path.Combine(UPLOAD_FOLDER_PATH, "users", "uploads", FormatCompanyInfo(companyId));



        public static string GenerateUniqueFileName(string fileNameWithExtension)
        {
            return Path.GetFileNameWithoutExtension(fileNameWithExtension).Replace(" ", "") +
                        DateTime.Now.ToFileTimeUtc().ToString() +
                        Path.GetExtension(fileNameWithExtension);
        }

        public static string GetFullPath(string folder, string file)
        {
            return Path.Combine(UPLOAD_FOLDER_PATH, folder, file);
        }

        public static string GetFullURL(string folder, string file)
        {
            string? apiURL = ConfigurationHelper.GetURL("API");

            Uri fileUri = new Uri(GetFullPath(folder, file));

            string fileUrl = fileUri.AbsoluteUri;

            fileUrl = fileUrl.Substring(fileUrl.IndexOf("wwwroot")).Replace("wwwroot", apiURL);

            return fileUrl;
        }

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
                Directory.CreateDirectory(Path.GetDirectoryName(path) ?? "");
        }



        public static string FormatCompanyInfo(long? companyId = null)
        {
            if (companyId is null || companyId == 0) return "common";

            return $"cid-{companyId}";
        }
    }
}
