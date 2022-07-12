using SegInfCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace SegInfEncripta
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = System.IO.File.ReadAllText(@"C:\Users\mathe\Desktop\SegInfEncripta\SegInfEncripta\Arquivos\source.txt");

            string[] chave = System.IO.File.ReadAllLines(@"C:\Users\mathe\Desktop\SegInfEncripta\SegInfEncripta\Arquivos\private.txt");

            Criptografar(texto, chave);
        }

        private static void Criptografar(string texto, string[] chaves)
        {
            byte[] textoAsBytes = Encoding.ASCII.GetBytes(texto);
            string textoBase64 = System.Convert.ToBase64String(textoAsBytes);

            List<string> list = new List<string>();

            var modulus = BigInteger.Parse(chaves[1]);

            var chave = BigInteger.Parse(chaves[0]);

            var chunkSize = TextChunk.BlockSize(modulus);

            System.IO.File.Delete(@"C:\Users\mathe\Desktop\SegInfEncripta\SegInfEncripta\Arquivos\dest.txt");

            var teste = textoBase64.Split(textoBase64, chunkSize);

            foreach (var x in Split(textoBase64, chunkSize))
            {
                var originalChunk = new TextChunk(x).bigIntValue();
                var encodedChunk = BigInteger.ModPow(originalChunk, chave, modulus);
                list.Add(encodedChunk.ToString());
            }

            System.IO.File.WriteAllLines(@"C:\Users\mathe\Desktop\SegInfEncripta\SegInfEncripta\Arquivos\dest.txt", list);
        }

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
