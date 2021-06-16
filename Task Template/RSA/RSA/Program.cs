using System;
using System.IO;


namespace RSA
{
    class Program
    {
        #region static variables
        static StreamReader sr;
        static int testCasesCount;
        static BigInteger n1;
        static BigInteger n2;
        static BigInteger B;
        static BigInteger P;
        static BigInteger M;
        static BigInteger mOrEm;
        static BigInteger eOrD;
        static BigInteger N;
        static BigInteger expectedResult;
        static BigInteger actualResult;
        static Tuple<BigInteger, BigInteger> divModExpectedResult;
        static Tuple<BigInteger, BigInteger> divModActualResult;

        static bool isCorrect = true;
        #endregion

        #region IO
        static void Main(string[] args)
        {
            Console.WriteLine("RSA Task:\n[1] Multiplication\n[2] Div-Mod\n[3] Mod of Power\n[4] RSA Encryption");
            Console.Write("\nEnter your choice [1-4]: ");
            char choice = (char)Console.ReadLine()[0];
            do
            {
                switch (choice)
                {
                    case '1':
                        choice = ReadSampleOrComplete("Multiplication");
                        if (choice == '1')
                        {
                            sr = new StreamReader("MultiplicationSample.txt");
                            testCasesCount = int.Parse(sr.ReadLine());
                            for (int i = 0; i < testCasesCount; i++)
                            {
                                n1 = new BigInteger(sr.ReadLine());
                                n2 = new BigInteger(sr.ReadLine());
                                expectedResult = new BigInteger(sr.ReadLine());
                                actualResult = BigInteger.Multiply(n1, n2);
                                Console.WriteLine("Case " + i + ": ");
                                Console.WriteLine("a = " + n1.Number_getter() + ", b = " + n1.Number_getter());
                                if (expectedResult != actualResult)
                                {
                                    Console.WriteLine("Wrong Answer. \nYour output = " + actualResult + "\nExpected Output = " + expectedResult);
                                    isCorrect = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Correct! \nYour output = " + actualResult + "\nExpected Output = " + expectedResult);
                                }
                            }

                            if (isCorrect)
                            {
                                Console.Write("Sample tests are correct. Do you want to run Complete tests [y/n]");
                                char ch = Console.ReadLine()[0];
                                if (ch == 'y' || ch == 'Y')
                                {
                                    choice = '2';
                                }
                            }
                        }
                        if (choice == '2')
                        {
                            sr = new StreamReader("MultiplicationComplete.txt");
                            testCasesCount = int.Parse(sr.ReadLine());
                            for (int i = 0; i < testCasesCount; i++)
                            {
                                n1 = new BigInteger(sr.ReadLine());
                                n2 = new BigInteger(sr.ReadLine());
                                expectedResult = new BigInteger(sr.ReadLine());
                                actualResult = BigInteger.Multiply(n1, n2);
                                if (expectedResult != actualResult)
                                {
                                    Console.WriteLine("Wrong Answer. \nYour output = " + actualResult + "\nExpected Output = " + expectedResult);
                                    isCorrect = false;
                                    break;
                                }

                            }

                            if (isCorrect)
                            {
                                Console.WriteLine("Congratulations !! Your BigInteger multiplication worked correctly on the complete tests (Y)");
                            }
                        }
                        break;
                    case '2':
                        choice = ReadSampleOrComplete("Div-Mod");
                        if (choice == '1')
                        {
                            sr = new StreamReader("DivModSample.txt");
                            testCasesCount = int.Parse(sr.ReadLine());
                            for (int i = 0; isCorrect && i < testCasesCount; i++)
                            {
                                n1 = new BigInteger(sr.ReadLine());
                                n2 = new BigInteger(sr.ReadLine());
                                BigInteger q = new BigInteger(sr.ReadLine());
                                BigInteger r = new BigInteger(sr.ReadLine());
                                divModExpectedResult = new Tuple<BigInteger, BigInteger>(q, r);
                                divModActualResult = BigInteger.DivMod(n1, n2);
                                Console.WriteLine("Case " + i + ": ");
                                Console.WriteLine("a = " + n1.Number_getter() + ", b = " + n1.Number_getter());
                                if (divModActualResult != divModExpectedResult)
                                {
                                    Console.WriteLine("Wrong Answer.");
                                    isCorrect = false;
                                }
                                else
                                {
                                    Console.WriteLine("Correct!");
                                }
                                Console.WriteLine("Your output: q = " + divModActualResult.Item1 + " r = " + divModActualResult.Item2 +
                                        "\nExpected Output : q = " + divModExpectedResult.Item1 + " r = " + divModExpectedResult.Item2);
                            }

                            if (isCorrect)
                            {
                                Console.Write("Sample tests are correct. Do you want to run Complete tests [y/n]");
                                char ch = Console.ReadLine()[0];
                                if (ch == 'y' || ch == 'Y')
                                {
                                    choice = '2';
                                }
                            }
                        }
                        if (choice == '2')
                        {
                            sr = new StreamReader("DivModComplete.txt");
                            testCasesCount = int.Parse(sr.ReadLine());
                            for (int i = 0; isCorrect && i < testCasesCount; i++)
                            {
                                n1 = new BigInteger(sr.ReadLine());
                                n2 = new BigInteger(sr.ReadLine());
                                BigInteger q = new BigInteger(sr.ReadLine());
                                BigInteger r = new BigInteger(sr.ReadLine());
                                divModExpectedResult = new Tuple<BigInteger, BigInteger>(q, r);
                                divModActualResult = BigInteger.DivMod(n1, n2);
                                if (divModActualResult != divModExpectedResult)
                                {
                                    Console.WriteLine("Wrong Answer.");
                                    isCorrect = false;
                                }
                                else
                                {
                                    Console.WriteLine("Correct!");
                                }
                            }

                            if (isCorrect)
                            {
                                Console.WriteLine("Congratulations !! Your BigInteger div-mod worked correctly on the complete tests (Y)");
                            }
                        }
                        break;
                    case '3':
                        choice = ReadSampleOrComplete("Mod of Power");
                        if (choice == '1')
                        {
                            sr = new StreamReader("ModOfPowerSample.txt");
                            testCasesCount = int.Parse(sr.ReadLine());
                            for (int i = 0; isCorrect && i < testCasesCount; i++)
                            {
                                B = new BigInteger(sr.ReadLine());
                                P = new BigInteger(sr.ReadLine());
                                M = new BigInteger(sr.ReadLine());
                                expectedResult = new BigInteger(sr.ReadLine());
                                actualResult = BigInteger.ModOfPower(B, P, M);
                                Console.WriteLine("Case " + i + ": ");
                                Console.WriteLine("B = " + B.Number_getter() + ", P = " + P.Number_getter() + ", M = " + M.Number_getter());
                                if (expectedResult != actualResult)
                                {
                                    Console.WriteLine("Wrong Answer.");
                                    isCorrect = false;
                                }
                                else
                                {
                                    Console.WriteLine("Correct!");
                                }
                                Console.WriteLine("Your output = " + actualResult +
                                        "\nExpected Output = " + expectedResult);
                            }

                            if (isCorrect)
                            {
                                Console.Write("Sample tests are correct. Do you want to run Complete tests [y/n]");
                                char ch = Console.ReadLine()[0];
                                if (ch == 'y' || ch == 'Y')
                                {
                                    choice = '2';
                                }
                            }
                        }
                        if (choice == '2')
                        {
                            sr = new StreamReader("ModOfPowerComplete.txt");
                            testCasesCount = int.Parse(sr.ReadLine());
                            for (int i = 0; isCorrect && i < testCasesCount; i++)
                            {
                                B = new BigInteger(sr.ReadLine());
                                P = new BigInteger(sr.ReadLine());
                                M = new BigInteger(sr.ReadLine());
                                expectedResult = new BigInteger(sr.ReadLine());
                                actualResult = BigInteger.ModOfPower(B, P, M);
                                if (expectedResult != actualResult)
                                {
                                    Console.WriteLine("Wrong Answer.");
                                    isCorrect = false;
                                }
                                else
                                {
                                    Console.WriteLine("Correct!");
                                }
                                Console.WriteLine("Your output = " + actualResult +
                                        "\nExpected Output = " + expectedResult);
                            }

                            if (isCorrect)
                            {
                                Console.WriteLine("Congratulations !! Your BigInteger Mod of Power worked correctly on the complete tests (Y)");
                            }
                        }
                        break;
                    case '4':
                        choice = ReadSampleOrComplete("RSA Encryption");
                        if (choice == '1')
                        {
                            sr = new StreamReader("RSASample.txt");
                            testCasesCount = int.Parse(sr.ReadLine());
                            for (int i = 0; isCorrect && i < testCasesCount; i++)
                            {
                                N = new BigInteger(sr.ReadLine());
                                eOrD = new BigInteger(sr.ReadLine());
                                mOrEm = new BigInteger(sr.ReadLine());
                                string mode = sr.ReadLine();
                                expectedResult = new BigInteger(sr.ReadLine());
                                actualResult = BigInteger.ModOfPower(mOrEm, eOrD, N);
                                Console.WriteLine("Case " + i + ": ");
                                if (mode == "0") // encrypt
                                {
                                    Console.WriteLine("M = " + mOrEm.Number_getter() + ", e = " + eOrD.Number_getter() + ", N = " + N.Number_getter());
                                }
                                else // decrypt
                                {
                                    Console.WriteLine("E(M) = " + mOrEm.Number_getter() + ", d = " + eOrD.Number_getter() + ", N = " + N.Number_getter());
                                }

                                if (expectedResult != actualResult)
                                {
                                    Console.WriteLine("Wrong Answer.");
                                    isCorrect = false;
                                }
                                else
                                {
                                    Console.WriteLine("Correct!");
                                }
                                Console.WriteLine("Your output = " + actualResult +
                                        "\nExpected Output = " + expectedResult);
                            }

                            if (isCorrect)
                            {
                                Console.Write("Sample tests are correct. Do you want to run Complete tests [y/n]");
                                char ch = Console.ReadLine()[0];
                                if (ch == 'y' || ch == 'Y')
                                {
                                    choice = '2';
                                }
                            }
                        }
                        if (choice == '2')
                        {
                            sr = new StreamReader("RSAComplete.txt");
                            testCasesCount = int.Parse(sr.ReadLine());
                            for (int i = 0; isCorrect && i < testCasesCount; i++)
                            {
                                N = new BigInteger(sr.ReadLine());
                                eOrD = new BigInteger(sr.ReadLine());
                                mOrEm = new BigInteger(sr.ReadLine());
                                string mode = sr.ReadLine();
                                expectedResult = new BigInteger(sr.ReadLine());
                                actualResult = BigInteger.ModOfPower(mOrEm, eOrD, N);

                                if (expectedResult != actualResult)
                                {
                                    Console.WriteLine("Wrong Answer.");
                                    isCorrect = false;
                                }
                            }

                            if (isCorrect)
                            {
                                Console.WriteLine("Congratulations !! RSA worked correctly on the complete tests (Y)");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.Write("\nDo you want to [c]ontinue or [q]uit \nEnter your choice [q or c]: ");
                char c = Console.ReadLine()[0];
                if (c == 'Q' || c == 'q')
                {
                    break;
                }
            } while (true);


        }

        static char ReadSampleOrComplete(string taskName)
        {
            Console.WriteLine(taskName + ":\n[1] Sample test cases\n[2] Complete test cases");
            Console.Write("\nEnter your choice [1-2]: ");
            return Console.ReadLine()[0];
        }
        #endregion
    }
}
