using SegInfCore.Core;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SegInfDecripta
{
    class Program
    {
        static void Main(string[] args)
        {
            //private.txt
            string[] chave = System.IO.File.ReadAllLines(@"C:\Users\mathe\Desktop\SegInfEncripta\SegInfEncripta\Arquivos\private.txt");

            //source.txt
            string[] texto = System.IO.File.ReadAllLines(@"C:\Users\mathe\Desktop\SegInfEncripta\SegInfEncripta\Arquivos\source.txt");

            Descriptografar(texto, chave);
        }

        private static void Descriptografar(string[] texto, string[] chaves)
        {
            var stringBase64 = "";
            foreach (var x in texto) 
            {
                var aux = new TextChunk(x);

                var modulus = BigInteger.Parse(chaves[1]);

                var chave = BigInteger.Parse(chaves[0]);

                var response = BigInteger.ModPow(aux.bigIntValue(), chave, modulus);

                stringBase64 += new TextChunk(response).StringVal;
            }

            byte[] bytes = System.Convert.FromBase64String(stringBase64);

            //dest.txt
            System.IO.File.Delete(@"C:\Users\mathe\Desktop\SegInfEncripta\SegInfEncripta\Arquivos\dest.txt");

            //dest.txt
            System.IO.File.WriteAllText(@"C:\Users\mathe\Desktop\SegInfEncripta\SegInfEncripta\Arquivos\dest.txt", Encoding.ASCII.GetString(bytes));
        }
    }
}
