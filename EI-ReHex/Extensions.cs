using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EIReHex
{
    public static class Extensions
    {
        public static bool Same(this string s, string another)
        {
            if (s == null)
            {
                return another == null;
            }
            else
            {
                return s.Equals(another, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public static string RemoveSpaces(this string s)
        {
            return Regex.Replace(s, @"[\s\t\r\n]", string.Empty);
        }

        public static byte[] ParseAsHex(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return new byte[] { };
            }

            s = s.RemoveSpaces();

            return Enumerable.Range(0, s.Length)
                .Where(n => n % 2 == 0)
                .Select(n => Convert.ToByte(s.Substring(n, 2), 16))
                .ToArray();
        }

        public static byte?[] ParseAsHexPattern(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return new byte?[] { };
            }

            s = s.RemoveSpaces();

            return Enumerable.Range(0, s.Length)
                .Where(n => n % 2 == 0)
                .Select(n => {
                    var hex = s.Substring(n, 2);
                    return hex.Same("XX")
                        ? (byte?)null
                        : Convert.ToByte(hex, 16);
                })
                .ToArray();
        }

        public static int FindBytes(this byte[] src, byte[] bytes)
        {
            int length = src.Length - bytes.Length + 1;
            
            for (int i = 0; i < length; i++)
            {
                if (src[i] != bytes[0]) continue;
                
                for (int j = bytes.Length - 1; j >= 1; j--)
                {
                    if (src[i + j] != bytes[j]) break;
                    if (j == 1) return i;
                }
            }

            return -1;
        }

        public static int FindBytesPattern(this byte[] src, byte?[] pattern)
        {
            int length = src.Length - pattern.Length + 1;

            for (int i = 0; i < length; i++)
            {
                if (src[i] != pattern[0]) continue;

                for (int j = pattern.Length - 1; j >= 1; j--)
                {
                    if (pattern[j].HasValue && src[i + j] != pattern[j].Value) break;
                    if (j == 1) return i;
                }
            }

            return -1;
        }
    }
}
