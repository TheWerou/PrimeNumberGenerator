using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace LiczbyPierwsze
{
    public static class RabinMiler
    {

        public static void BasicGeneratePrimeNumber(uint begin, uint end)
        {
            for (uint i = begin; i < end; i++)
            {
                if (RabinMiler.CheckIfPrimeNumberBignumbers(i, 2))
                {
                    Console.WriteLine(i.ToString() + " ");
                }
            }
        }

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

        public static BigInteger GetRandomPositivOddBigInteger(int bitLength)
        {
            Random random = new Random();
            byte[] data = new byte[bitLength];
            random.NextBytes(data);
            BigInteger primeNumber = new BigInteger(data);

            if (primeNumber.Sign == -1)
            {
                primeNumber = primeNumber * -1;
            }

            if (primeNumber % 2 == 0)
            {
                primeNumber += 1;
            }
            return primeNumber;
        }

        public static bool CheckIfPrimeNumberBignumbers(this BigInteger source, int certainty)
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
    }
}
