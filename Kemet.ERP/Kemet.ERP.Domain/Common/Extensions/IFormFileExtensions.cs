using Kemet.ERP.Domain.Common.Utilities;
using Microsoft.AspNetCore.Http;

namespace Kemet.ERP.Domain.Common.Extensions
{
    public static class IFormFileExtensions
    {
        public async static Task<string> Upload(this IFormFile file, string uploadTo)
            => await UploadHelper.Upload(file, uploadTo, "", "");
    }
}
