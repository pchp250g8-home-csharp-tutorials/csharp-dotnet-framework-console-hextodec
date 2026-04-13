using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HexToDec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const uint MAX_INT = uint.MaxValue;
            var nDecNum = 0L;
            var nHexPower = 1L;
            var nMaxHexLen = Math.Ceiling(Math.Log(MAX_INT, 16));
            var oRegEx = new Regex("^[0-9A-Fa-f]+$");
            Console.WriteLine("Input a hexadecimal number");
            var strLine = Console.ReadLine();
            var nStrLen = strLine.Length;
            var bIsMatch = oRegEx.IsMatch(strLine);
            var bRightString = (nStrLen <= nMaxHexLen) && (bIsMatch);
            if (!bRightString)
            {
                Console.WriteLine("Wrong hexadecimal number format!!!");
                Console.Read();
                return;
            }
            for (int i = 0; i < nStrLen; i++)
            {
                int nHexDigit = 0;
                char chHexDigit = strLine[nStrLen - 1 - i];
                if (chHexDigit >= '0' && chHexDigit <= '9')
                    nHexDigit = chHexDigit - '0';
                else if (chHexDigit >= 'a' && chHexDigit <= 'f')
                    nHexDigit = 10 + chHexDigit - 'a';
                else if (chHexDigit >= 'A' && chHexDigit <= 'F')
                    nHexDigit = 10 + chHexDigit - 'A';
                nDecNum += (nHexDigit * nHexPower);
                nHexPower *= 16;
            }
            Console.WriteLine("The decimal equivalent of the hexadecimal number {0} is {1}", strLine, nDecNum);
            Console.Read();
        }
    }
}
