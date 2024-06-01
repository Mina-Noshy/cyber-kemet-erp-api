using Kemet.ERP.Domain.Common.Utilities;

namespace Kemet.ERP.Domain.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ToMD5(this string str)
            => HashingHelper.GetMD5Hash(str);
    }
}
