using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FreelanceHunt.Common
{

    public abstract class Encoding
    {
        #region toString

        public virtual char[] GetChars(byte[] bytes)
        {
            return GetChars(bytes, 0, bytes.Length);
        }

        public abstract char[] GetChars(byte[] bytes, int index, int count);

        public virtual int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            var tmp = GetChars(bytes, byteIndex, byteCount);
            Array.Copy(tmp, 0, chars, charIndex, tmp.Length);
            return tmp.Length;
        }

        public virtual string GetString(byte[] bytes)
        {
            return GetString(bytes, 0, bytes.Length);
        }

        public virtual string GetString(byte[] bytes, int start, int count)
        {
            return new string(GetChars(bytes, start, count));
        }

        public virtual byte[] GetBytes(char[] chars)
        {
            return GetBytes(chars, 0, chars.Length);
        }

        #endregion

        #region toBytes

        public virtual byte[] GetBytes(string s)
        {
            var tmp = s.ToCharArray();
            return GetBytes(tmp, 0, tmp.Length);
        }

        public abstract byte[] GetBytes(char[] chars, int index, int count);

        public virtual int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            var tmp = GetBytes(chars, charIndex, charCount);
            Array.Copy(tmp, 0, bytes, byteIndex, tmp.Length);
            return tmp.Length;
        }

        public virtual int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            return GetBytes(s.ToCharArray(), charIndex, charCount, bytes, byteIndex);
        }

        #endregion

        #region counts

        public virtual int GetByteCount(char[] chars)
        {
            return GetByteCount(chars, 0, chars.Length);
        }

        public virtual int GetByteCount(String s)
        {
            var tmp = s.ToCharArray();
            return GetByteCount(tmp, 0, tmp.Length);
        }

        public abstract int GetByteCount(char[] chars, int index, int count);

        public virtual int GetCharCount(byte[] bytes)
        {
            return GetCharCount(bytes, 0, bytes.Length);
        }

        public abstract int GetCharCount(byte[] bytes, int index, int count);

        #endregion

        #region names

        public abstract int CodePage { get; }
        public abstract string EncodingName { get; }
        public abstract string WebName { get; }

        private static readonly object syncRoot = new object();

        private static Dictionary<string, int> NameMap;

        public static Encoding GetEncoding(string name)
        {
            if (NameMap == null)
                lock (syncRoot)
                    if (NameMap == null)
                        NameMap = new Dictionary<string, int> {
                            { "unicode", 1200 },
                            { "utf-16", 1200 },
                            { "cp1200", 1200 },
                            { "ucs-2", 1200 },
                            { "utf-16le", 1200 },
                            { "unicodefffe", 1201 },
                            { "utf-16be", 1201 },
                            { "cp1201", 1201 },
                            { "us-ascii", 20127 },
                            { "ansi_x3.4-1968", 20127 },
                            { "ansi_x3.4-1986", 20127 },
                            { "ascii", 20127 },
                            { "cp367", 20127 },
                            { "csascii", 20127 },
                            { "ibm367", 20127 },
                            { "iso_646.irv:1991", 20127 },
                            { "iso646-us", 20127 },
                            { "iso-ir-6", 20127 },
                            { "us", 20127 },
                            { "utf-8", 65001 },
                            { "unicode-1-1-utf-8", 65001 },
                            { "unicode-2-0-utf-8", 65001 },
                            { "x-unicode-2-0-utf-8", 65001 },
                            { "cp65001", 65001 },
                        };
            name = name.ToLower();
            if (NameMap.ContainsKey(name))
                return GetEncoding(NameMap[name]);
            throw new ArgumentException("'" + name + "' is not a supported encoding name.", "name");
        }

        public static Encoding GetEncoding(int codepage)
        {
            switch (codepage)
            {
                case 0: return Default;
                case 1200: return Unicode;
                case 1201: return BigEndianUnicode;
                case 65001: return UTF8;
                case 20127: return ASCII;
                default:
                    if (0 <= codepage && codepage <= 65535)
                        throw new NotSupportedException("No data is available for encoding " + codepage + ".");
                    throw new ArgumentException("Valid values are between 0 and 65535, inclusive.", "codepage");
            }
        }

        #endregion

        public static readonly Encoding ASCII = new Enc20127();
        public static readonly Encoding BigEndianUnicode = new EncodingWrapper(System.Text.Encoding.BigEndianUnicode);
        public static readonly Encoding Default = UTF8;
        public static readonly Encoding Unicode = new EncodingWrapper(System.Text.Encoding.Unicode);
        public static readonly Encoding UTF8 = new EncodingWrapper(System.Text.Encoding.UTF8);

        private sealed class EncodingWrapper : Encoding
        {
            readonly System.Text.Encoding enc;

            public EncodingWrapper(System.Text.Encoding enc)
            {
                this.enc = enc;
            }

            public override int GetByteCount(char[] chars)
            {
                return enc.GetByteCount(chars);
            }

            public override int GetByteCount(char[] chars, int index, int count)
            {
                return enc.GetByteCount(chars, index, count);
            }

            public override int GetByteCount(string s)
            {
                return enc.GetByteCount(s);
            }

            public override byte[] GetBytes(char[] chars)
            {
                return enc.GetBytes(chars);
            }

            public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
            {
                return enc.GetBytes(chars, charIndex, charCount, bytes, byteIndex);
            }

            public override byte[] GetBytes(char[] chars, int index, int count)
            {
                return enc.GetBytes(chars, index, count);
            }

            public override byte[] GetBytes(string s)
            {
                return enc.GetBytes(s);
            }

            public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
            {
                return enc.GetBytes(s, charIndex, charCount, bytes, byteIndex);
            }

            public override int GetCharCount(byte[] bytes)
            {
                return enc.GetCharCount(bytes);
            }

            public override int GetCharCount(byte[] bytes, int index, int count)
            {
                return enc.GetCharCount(bytes, index, count);
            }

            public override char[] GetChars(byte[] bytes)
            {
                return enc.GetChars(bytes);
            }

            public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
            {
                return enc.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
            }

            public override char[] GetChars(byte[] bytes, int index, int count)
            {
                return enc.GetChars(bytes, index, count);
            }

            public override string GetString(byte[] bytes, int start, int count)
            {
                return enc.GetString(bytes, start, count);
            }

            public override string WebName
            {
                get { return enc.WebName; }
            }

            public override int CodePage
            {
                get
                {
                    switch (WebName)
                    {
                        case "utf-16BE":
                        case "unicodeFFFE": return 1201;
                        case "utf-16": return 1200;
                        case "utf-8": return 65001;
                        default: return -1;
                    }
                }
            }

            public override string EncodingName
            {
                get
                {
                    switch (WebName)
                    {
                        case "utf-16BE":
                        case "unicodeFFFE": return "Unicode (Big-Endian)";
                        case "utf-16": return "Unicode";
                        case "utf-8": return "Unicode (UTF-8)";
                        default: return "(Unknown)";
                    }
                }
            }
        }

        // US-ASCII
        private sealed class Enc20127 : Encoding
        {
            #region conversion

            public override char[] GetChars(byte[] bytes, int index, int count)
            {
                var result = new char[count];
                for (var i = 0; i < result.Length; i++)
                {
                    var b = bytes[i + index];
                    result[i] = (b > 127) ? '?' : (char)b;
                }
                return result;
            }

            public override byte[] GetBytes(char[] chars, int index, int count)
            {
                var result = new byte[count];
                for (var i = 0; i < result.Length; i++)
                {
                    var c = chars[i + index];
                    result[i] = (c > 127) ? (byte)'?' : (byte)c;
                }
                return result;
            }

            public override int GetByteCount(char[] chars, int index, int count)
            {
                return count;
            }

            public override int GetCharCount(byte[] bytes, int index, int count)
            {
                return count;
            }

            #endregion

            public override int CodePage
            {
                get { return 20127; }
            }

            public override string EncodingName
            {
                get { return "US-ASCII"; }
            }

            public override string WebName
            {
                get { return "us-ascii"; }
            }
        }
    }

}
