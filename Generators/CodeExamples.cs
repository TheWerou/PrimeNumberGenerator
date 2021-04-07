using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LiczbyPierwsze.Generators
{
    public static class CodeExamples
    {
        #region BasicRabinMiler
        public static bool RabinMilerTest(int n, int k)
        {
            if ((n < 2) || (n % 2 == 0)) return (n == 2);

            int s = n - 1;
            while (s % 2 == 0) s >>= 1;

            Random r = new Random();
            for (int i = 0; i < k; i++)
            {
                int a = r.Next(n - 1) + 1;
                int temp = s;
                long mod = 1;
                for (int j = 0; j < temp; ++j) mod = (mod * a) % n;
                while (temp != n - 1 && mod != 1 && mod != n - 1)
                {
                    mod = (mod * mod) % n;
                    temp *= 2;
                }

                if (mod != n - 1 && temp % 2 == 0) return false;
            }
            return true;
        }
        #endregion
        
        #region RabinMilerBig
        public static bool RabinMilerTestBigInteger(this BigInteger source, int certainty)
        {
            if (source == 2 || source == 3)
                return true;
            if (source < 2 || source % 2 == 0)
                return false;

            BigInteger d = source - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            byte[] bytes = new byte[source.ToByteArray().LongLength];
            BigInteger a;
            Random rnd = new Random();
            for (int i = 0; i < certainty; i++)
            {
                do
                {
                    rnd.NextBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= source - 2);

                BigInteger x = BigInteger.ModPow(a, d, source);
                if (x == 1 || x == source - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, source);

                    if (x == 1)
                        return false;
                    if (x == source - 1)
                        break;
                }

                if (x != source - 1)
                    return false;
            }

            return true;
        }
        #endregion

        #region GenerateFromTo
        public static void GeneratePrimeNumber(string begin, string end)
        {
            var beginNumber = BigInteger.Parse(begin);
            var endNumber = BigInteger.Parse(end);
            for (var i = beginNumber; i < endNumber; i++)
            {
                if (RabinMiler.CheckIfPrimeNumberBignumbers(i, 2))
                {
                    Console.WriteLine(i.ToString() + " ");
                }
            }
        }
        #endregion

        #region GenerateToBitLenght
        public static BigInteger GeneratePrimeNumberbyLenght(int primeLenght, int certainty)
        {
            BigInteger primeNumber = BigInteger.One;
            BigInteger iterator = 2;
            while (primeLenght >= primeNumber.ToString().Length)
            {
                if (primeLenght <= primeNumber.ToString().Length && RabinMiler.CheckIfPrimeNumberBignumbers(primeLenght, certainty))
                {
                    primeNumber = iterator;
                    Console.WriteLine(primeNumber);
                }
                iterator += 2;
                Console.WriteLine(iterator);
            }
            return primeNumber;
        }
        #endregion

        #region FastGenerateToBitLenght
        public static BigInteger FastGeneratePrimeNumberbyLenght(int primeBitLenght, int certainty)
        {
            primeBitLenght = primeBitLenght / 8;

            BigInteger primeNumber = RabinMiler.GetRandomPositivOddBigInteger(primeBitLenght);

            BigInteger iterator = primeNumber;

            while (true)
            {
                if (RabinMiler.CheckIfPrimeNumberBignumbers(iterator, certainty))
                {
                    primeNumber = iterator;

                    if (primeBitLenght <= primeNumber.ToByteArray().Length)
                    {
                        break;
                    }
                }
                iterator += 2;

            }
            return primeNumber;
        }
        #endregion

    }
}
