namespace Kemet.ERP.Domain.Common.Constants
{
    public static class FileServerPath
    {
        private static readonly string RootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private static readonly string UploadPath = Path.Combine(RootPath, "uploads");

        public static readonly string UserProfile = Path.Combine(UploadPath, "users", "profiles");
        public static readonly string UserUploads = Path.Combine(UploadPath, "users", "uploads");


    }
}
