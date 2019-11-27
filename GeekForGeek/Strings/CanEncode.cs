using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeekForGeek.Strings
{
    public class CanEncode
    {
        // abacda, xyxzlx --> true;
        // abba xyyz --> false;
        public static bool CheckIfEncode(string string1, string string2)
        {
            bool result = true;

            if (string1.Length != string2.Length)
                return false;

            Dictionary<char, char> mappingChar = new Dictionary<char, char>();

            char[] str1 = string1.ToCharArray();
            char[] str2 = string2.ToCharArray();

            for (int i = 0; i < str1.Count(); i ++)
            {
                if (!mappingChar.ContainsKey(str1[i]))
                {
                    mappingChar.Add(str1[i], str2[i]);
                }
                else
                {
                    if (mappingChar[str1[i]] != str2[i])
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
