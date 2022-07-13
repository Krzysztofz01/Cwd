using System.Linq;

namespace Cwd.Extensions
{
    internal static class StringArrayExtensions
    {
        public static bool HasParam(this string[] array, string param)
        {
            return array.Any(p => p.ToLower() == param.ToLower());
        }

        public static bool HasParam(this string[] array, string shortParam, string longParam)
        {
            return array.HasParam(shortParam) || array.HasParam(longParam);
        }
    }
}
