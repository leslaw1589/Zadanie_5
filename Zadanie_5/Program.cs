using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_5
{
    class Program
    {
        private static int[] arabskie = { 1000, 500, 100, 50, 10, 5, 1 };
        private static char[] rzymskie = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
        private static int rzymskie_n = arabskie.Length;

        public static String ArabskieNaRzymskie(int number)
        {
            int i = 0; //position in arabic and roman arrays

            String result = "";

            if ((number > 3999) || (number <= 0))
            {
                return result;
            }

            while ((number > 0) && (i < rzymskie_n))
            {
                if (number >= arabskie[i])
                {
                    number -= arabskie[i];
                    result += rzymskie[i];
                }
                else if ((i % 2 == 0) &&
                (i < rzymskie_n - 2) && // 9xx condition
                (number >= arabskie[i] - arabskie[i + 2]) &&
                (arabskie[i + 2] != arabskie[i] - arabskie[i + 2]))
                {
                    number -= arabskie[i] - arabskie[i + 2];
                    result += rzymskie[i + 2];
                    result += rzymskie[i];
                    i++;
                }
                else if ((i % 2 == 1) &&
                (i < rzymskie_n - 1) && //4xx condition
                (number >= arabskie[i] - arabskie[i + 1]) &&
                (arabskie[i + 1] != arabskie[i] - arabskie[i + 1]))
                {
                    number -= arabskie[i] - arabskie[i + 1];
                    result += rzymskie[i + 1];
                    result += rzymskie[i];
                    i++;
                }
                else
                {
                    i++;
                }
            }

            return result;
        }

        public static int RzymskieNaArabskie(String number)
        {
            int i = 0, //position in arabic and roman arrays
            j = 0, //position in number
            result = 0,
            length = 0;

            length = number.Length;

            while ((j < length) && (i < rzymskie_n))
            {
                if (number[j] == rzymskie[i])
                {
                    result += arabskie[i];
                    j++;
                }
                else if ((i % 2 == 0) &&
                (i < rzymskie_n - 2) && // 9xx condition
                (j < length - 1) &&
                (number[j] == rzymskie[i + 2]) &&
                (number[j + 1] == rzymskie[i]))
                {
                    result += arabskie[i] - arabskie[i + 2];
                    j += 2;
                    i++;
                }
                else if ((i % 2 == 1) &&
                (i < rzymskie_n - 1) && //4xx condition
                (j < length - 1) &&
                (number[j] == rzymskie[i + 1]) &&
                (number[j + 1] == rzymskie[i]))
                {
                    result += arabskie[i] - arabskie[i + 1];
                    j += 2;
                    i++;
                }
                else
                {
                    i++;
                }
            }

            //there was an error during conversion
            if (i == rzymskie_n)
            {
                result = -1;
            }

            return result;
        }


        static void Main(string[] args)
        {
            String rzymska;

            rzymska = ArabskieNaRzymskie(1582);
            Console.WriteLine("Cyfra {0} to inaczej {1} ", RzymskieNaArabskie(rzymska), rzymska);

            rzymska = ArabskieNaRzymskie(3989);
            Console.WriteLine("Cyfra {0} to inaczej {1} ", RzymskieNaArabskie(rzymska), rzymska);

            rzymska = ArabskieNaRzymskie(10);
            Console.WriteLine("Cyfra {0} to inaczej {1} ", RzymskieNaArabskie(rzymska), rzymska);

            Console.ReadKey();
        }

    }
}

