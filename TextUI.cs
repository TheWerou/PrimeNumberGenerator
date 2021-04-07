using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LiczbyPierwsze
{
    public class TextUI
    {
        public TextUI()
        {
            this.TextGui();
        }

        public bool TextGui()
        {
            while (true)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Menu.");
                Console.WriteLine("1. Test naprawde dużych liczb pierwszych");
                Console.WriteLine("2. Generowanie liczb pierwszych od do");
                Console.WriteLine("3. Generowanie o odpowiedniej dlugosci");
                Console.WriteLine("END. Zakończ");
                Console.Write("> ");
                var output = Console.ReadLine().ToUpper();
                
                switch (output)
                {
                    case "1":
                        if(this.TestBigNumbersTUI())
                        {
                            return true;
                        }
                        break;
                    case "2":
                        if(this.GenerateFromToTUI())
                        {
                            return true;
                        }
                        break;
                    case "3":
                        if(this.GenerateLenghtTUI())
                        {
                            return true;
                        }
                        break;
                    case "END":
                        return true;
                        
                }
            }
        }

        private bool TestBigNumbersTUI()
        {
            string option;

            while(true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------");
                Console.WriteLine("Test naprawde dużych liczb pierwszych.");
                Console.WriteLine("1. Sprobuj sam");
                Console.WriteLine("2. 512 bit 20 testów");
                Console.WriteLine("3. 1024 bit 20 testów");
                Console.WriteLine("4. 2048 bit 20 testów");
                Console.WriteLine("back.");
                Console.WriteLine("END. Zakończ");
                Console.Write("> ");
                option = Console.ReadLine().ToUpper();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        Console.Write("Podaj liczbę > ");
                        var output = Console.ReadLine().ToUpper();
                        Console.Write("Podaj liczbe testów > ");
                        var output2 = Console.ReadLine().ToUpper();
                        this.RealyBigCheck(BigInteger.Parse(output), Int32.Parse(output2));
                        Console.WriteLine("Nacisinij dowolny przycisk by kontynułować");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        var number = BigInteger.Parse("9160078037032412453242298933021552583482211558751975184751127708331723203866740588818168884069792349656193151948102110282018454774536799897861936084700209");
                        Console.WriteLine(number);
                        this.RealyBigCheck(number, 20);
                        Console.WriteLine("Nacisinij dowolny przycisk by kontynułować");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        var number2 = BigInteger.Parse("132340053734029265835731077121274239953937023339029907465854614860415132174236435801864003966155850492214971074865429592016061612443143187531322667351149973406267891780580791596090862858287482064834684377075915077991396067895563017719632890127751597641050126973847614301700025779040067860409174582903412373893");
                        Console.WriteLine(number2);
                        this.RealyBigCheck(number2, 20);
                        Console.WriteLine("Nacisinij dowolny przycisk by kontynułować");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        var number3 = BigInteger.Parse("22565801964206890988541584695915484548428139481392818060426180628697405997975383733864055232555523083011393653476060281721167941603075552172531623322075208952957549533244160737755286726967453123665085375014103381721635789269100843266562918141494944306613454992432759604840738916022046199576003217066958296658018613514751436114291579599895096864700194059561920081772752791721904930987838316304196661629911452491152470071547326640975619270904342851865348540235619654219569411759589575792985932241411789305976054432047757125241375222936809025266129715700450215595506623712665557637756659980587063702222495517232806178999");
                        Console.WriteLine(number3);
                        this.RealyBigCheck(number3, 20);
                        Console.WriteLine("Nacisinij dowolny przycisk by kontynułować");
                        Console.ReadKey();
                        break;
                    case "BACK":
                        Console.Clear();
                        return false;
                    case "END":
                        Console.Clear();
                        return true;
                }
            }
        }

        private bool GenerateFromToTUI()
        {
            string option;
            while(true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------");
                Console.WriteLine("Generowanie liczb pierwszych od do");
                Console.WriteLine("1. Generowanie liczb pierwszych od do uint");
                Console.WriteLine("2. Generowanie liczb pierwszych od do string");
                Console.WriteLine("back.");
                Console.WriteLine("END. Zakończ");
                Console.Write("> ");
                option = Console.ReadLine().ToUpper();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Podaj odkąd generować liczby pierwsze");
                        var output = Console.ReadLine().ToUpper();
                        Console.WriteLine("Podaj dokąd generować liczby pierwsze");
                        var output2 = Console.ReadLine().ToUpper();
                        Console.WriteLine("Liczby pierwsze:");
                        GenerateFromToUINT(UInt32.Parse(output), UInt32.Parse(output2));
                        Console.WriteLine("Nacisinij dowolny przycisk by kontynułować");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Podaj odkąd generować liczby pierwsze");
                        var output3 = Console.ReadLine().ToUpper();
                        Console.WriteLine("Podaj dokąd generować liczby pierwsze");
                        var output4 = Console.ReadLine().ToUpper();
                        Console.WriteLine("Liczby pierwsze:");
                        GenerateFromToString(output3, output4);
                        Console.WriteLine("Nacisinij dowolny przycisk by kontynułować");
                        Console.ReadKey();
                        break;
                    case "BACK":
                        Console.Clear();
                        return false;
                    case "END":
                        Console.Clear();
                        return true;
                }
            }
        }

        private bool GenerateLenghtTUI()
        {
            string option;
            while(true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------");
                Console.WriteLine("Generowanie o odpowiedniej dlugosci");
                Console.WriteLine("1. Sprobuj sam");
                Console.WriteLine("2. 512 bit 20 prob");
                Console.WriteLine("3. 1024 bit 20 prob");
                Console.WriteLine("4. 2048 bit 20 prob");
                Console.WriteLine("back.");
                Console.WriteLine("END. Zakończ");
                Console.Write("> ");
                option = Console.ReadLine().ToUpper();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        Console.Write("Podaj długość w bitach liczby > ");
                        var output4 = Console.ReadLine().ToUpper();
                        Console.Write("Podaj ilość testów > ");
                        var output5 = Console.ReadLine().ToUpper();
                        Console.Write("Normalny test ? (Y/n)> ");
                        var output6 = Console.ReadLine().ToUpper();
                        if(output6 == "N")
                        {
                            Console.WriteLine("Jedna liczba");
                            FastGenerateByLenght(Int32.Parse(output4), Int32.Parse(output5));
                        }
                        else
                        {
                            Console.WriteLine("Generacja do");
                            GenerateByLenght(Int32.Parse(output4), Int32.Parse(output5));
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        Console.Write("Wygenerować do czy pojedyńczą ? (Y/n) > ");
                        var output0 = Console.ReadLine().ToUpper();
                        if (output0 == "N")
                        {
                            Console.WriteLine("Jedna liczba");
                            FastGenerateByLenght(512, 20);
                        }
                        else
                        {
                            Console.WriteLine("Generacja do");
                            GenerateByLenght(512, 20);
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        Console.Write("Wygenerować do czy pojedyńczą ? (Y/n) > ");
                        var output1 = Console.ReadLine().ToUpper();
                        if (output1 == "N")
                        {
                            Console.WriteLine("Jedna liczba");
                            FastGenerateByLenght(1024, 20);
                            Console.WriteLine("Nacisinij dowolny przycisk by kontynułować");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Generacja do");
                            GenerateByLenght(1024, 20);
                            Console.WriteLine("Nacisinij dowolny przycisk by kontynułować");
                            Console.ReadKey();
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("----------------------------");
                        Console.Write("Wygenerować do czy pojedyńczą ? (Y/n) > ");
                        var output2 = Console.ReadLine().ToUpper();
                        if (output2 == "N")
                        {
                            Console.WriteLine("Jedna liczba");
                            FastGenerateByLenght(2048, 20);
                            Console.WriteLine("Nacisinij dowolny przycisk by kontynułować");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Generacja do");
                            GenerateByLenght(2048, 20);
                            Console.WriteLine("Nacisinij dowolny przycisk by kontynułować");
                            Console.ReadKey();
                        }
                        break;
                    case "BACK":
                        Console.Clear();
                        return false;
                    case "END":
                        Console.Clear();
                        return true;
                }
            }
        }

        private void GenerateFromToUINT(uint begin, uint end)
        {
            RabinMiler.BasicGeneratePrimeNumber(begin, end);
        }

        private void GenerateFromToString(string begin, string end)
        {
            RabinMiler.GeneratePrimeNumber(begin, end);
        }

        private void FastGenerateByLenght(int bitLenght, int certainty)
        {
            BigInteger output = RabinMiler.FastGeneratePrimeNumberbyLenght(bitLenght, certainty);
            Console.WriteLine("Ilość bitów: " + bitLenght);
            Console.WriteLine("Ilość znaków: " + output.ToString().Length);
            Console.WriteLine(output);
        }

        private void GenerateByLenght(int bitLenght, int certainty)
        {
            BigInteger output = RabinMiler.GeneratePrimeNumberbyLenght(bitLenght, certainty);
            Console.WriteLine("Ilość bitów: " + bitLenght);
            Console.WriteLine("Ilość znaków: " + output.ToString().Length);
            Console.WriteLine(output);
        }

        private void RealyBigCheck(BigInteger input, int certainty)
        {

            if (RabinMiler.CheckIfPrimeNumberBignumbers(input, certainty))
            {
                Console.WriteLine("To jest liczba pierwsza");
            }
            else
            {
                Console.WriteLine("To nie jest liczba pierwsza");
            }

        }
    }
}
