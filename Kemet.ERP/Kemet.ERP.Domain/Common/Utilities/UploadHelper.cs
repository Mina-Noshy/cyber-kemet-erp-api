using Microsoft.AspNetCore.Http;

namespace Kemet.ERP.Domain.Common.Utilities
{
    public static class UploadHelper
    {
        private readonly static decimal UPLOAD_MAX_SIZE = 10; // 10 Megabytes.

        private readonly static string UPLOAD_WHITE_LIST = @".jpg .jpeg .txt .mkv .flv .doc .docx
                                                             .png .gif .bmp .tiff .tif .pdf 
                                                             .rtf .csv .xls .xlsx .ppt .pptx
                                                             .mp3 .wav .ogg .mp4 .mov .avi";

        private readonly static string UPLOAD_BLACK_LIST = @".exe .bat .com .dll .java .class .jar .war .scr .msi 
                                                             .cab .c .h .cs .cpp .hpp .py .pyc .pyd .pyo .pyw .php 
                                                             .rb .go .js .css .html .htm .sql .cmd .swift .rs .ts .pl 
                                                             .sh .json .xml .md .yaml .yml";




        /// <summary>
        /// upload file to the server.
        /// </summary>
        /// <param name="file">file to upload on the server</param>
        /// <param name="uploadTo">folder name in upload folder on the server</param>
        /// <returns></returns>
        public static async Task<List<string>> Upload(List<IFormFile> files, string uploadTo, string userIp, string userAgent)
        {
            var result = new List<string>();

            foreach (var file in files)
            {
                if (file != null)
                {
                    string uploadedFile = await Upload(file, uploadTo, userIp, userAgent);

                    result.Add(uploadedFile);

                    //result.Add(GetFullURL(uploadTo, uploadedFile));
                }

            }

            return result;
        }

        /// <summary>
        /// upload file to the server.
        /// </summary>
        /// <param name="file">file to upload on the server</param>
        /// <param name="uploadTo">folder name in upload folder on the server</param>
        /// <returns></returns>
        public static async Task<string> Upload(IFormFile file, string uploadTo, string userIp, string userAgent)
        {
            CheckValidateFile(file, userIp, userAgent);

            if (file != null)
            {
                string uniqueFileName = IOHelper.GenerateUniqueFileName(file.FileName);

                string filePath = Path.Combine(uploadTo, uniqueFileName);

                IOHelper.CheckOrCreateDirectory(filePath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return uniqueFileName;

                //result.Add(GetFullURL(uploadTo, uniqueFileName));
            }

            return string.Empty;
        }

        /// <summary>
        /// delete file from the server.
        /// </summary>
        /// <param name="fileName">file name to delete from the server</param>
        /// <param name="deleteFrom">folder name in upload folder on the server</param>
        /// <returns></returns>
        public static List<string> Delete(List<string> files, string deleteFrom)
        {
            var result = new List<string>();

            foreach (var file in files)
            {
                string deletedFile = Delete(file, deleteFrom);
                result.Add(deletedFile);
            }

            return result;
        }

        /// <summary>
        /// delete file from the server.
        /// </summary>
        /// <param name="fileName">file name to delete from the server</param>
        /// <param name="deleteFrom">folder name in upload folder on the server</param>
        /// <returns></returns>
        public static string Delete(string file, string deleteFrom)
        {
            string fullPath = Path.Combine(deleteFrom, file);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return file;
            }

            return string.Empty;
        }

        private static void CheckValidateFile(IFormFile file, string userIp, string userAgent)
        {
            if (!UPLOAD_WHITE_LIST.Contains(Path.GetExtension(file.FileName), StringComparison.OrdinalIgnoreCase))
                throw (new NotImplementedException(GetHackerMsg(userIp, userAgent)));

            if (file.Length > (UPLOAD_MAX_SIZE * 1024 * 1024))
                throw (new NotImplementedException(GetFileOverSizeMsg(file.FileName, file.Length)));
        }









        private static string GetHackerMsg(string userIp, string userAgent)
        {
            return "Attention Hacker!," +
                " it seems like you're trying to upload a file that isn't allowed on our website. Our security measures are top-notch," +
                " and we don't tolerate malicious activity here. We've detected your attempt and taken appropriate action." +
                $" Your IP Address: {userIp}," +
                $" User-Agent: {userAgent}," +
                " Please remember that attempting to compromise our website is illegal and unethical." +
                " We take the security of our platform seriously and continuously monitor for any suspicious activity." +
                " If you believe this is a mistake or have any concerns, please reach out to our security team immediately." +
                " Thank you for your understanding." +
                " Best regards," +
                " Security Team";
        }


        private static string GetFileOverSizeMsg(string fileName, long size)
        {
            return $"It seems like you're attempting to upload a file named '{fileName}'," +
                $" that exceeds our size limit of {UPLOAD_MAX_SIZE} megabytes (MB)." +
                $" The size of the file you're trying to upload is '{size / 1024 / 1024} MB'.";
        }
    }
}
