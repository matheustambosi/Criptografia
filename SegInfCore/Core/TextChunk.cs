using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace SegInfCore.Core
{
    public class TextChunk
    {
        public string StringVal { get; set; }

        public TextChunk(string stringVal) 
        {
            StringVal = stringVal;
        }

        public TextChunk(BigInteger n)
        {
            BigInteger big256 = new BigInteger(256);
            BigInteger big0 = new BigInteger(0);

            if (n == big0)
            {
                StringVal = "0";
            }
            else
            {
                // extract characters and append to front of string
                // until remaining number is 0
                StringVal = "";
                while (n > big0)
                {
                    var resultado = BigInteger.DivRem(n,big256, out var resto);
                    int charNum = (int)resto;
                    StringVal = StringVal + (char)charNum;
                    n = resultado;
                }
            }
        }

        public BigInteger bigIntValue()
        {
            BigInteger big256 = new BigInteger(256);
            BigInteger result = new BigInteger(0);

            // in this encoding, first characters of stringVal are the
            // least significant part of the result
            for (int i = StringVal.Length - 1; i >= 0; i--)
            {
                result = BigInteger.Multiply(result,big256);
                var aux = StringVal.ToCharArray();
                result = BigInteger.Add(result,new BigInteger((int)aux.ToList()[i]));
            }
            return result;
        }

        public static int BlockSize(BigInteger N)
        {
            // value computed is log_2(N-1)
            BigInteger big1 = new BigInteger(1);
            BigInteger big2 = new BigInteger(2);

            int blockSize = 0;  // result
            BigInteger temp = BigInteger.Subtract(N,big1);
            while (temp.CompareTo(big1) > 0)
            {
                temp = BigInteger.Divide(temp,big2);
                blockSize++;
            }
            return blockSize / 8;
        }
    }
}
