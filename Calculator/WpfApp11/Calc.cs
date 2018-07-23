using System;

namespace WpfApp11
{
    internal class Calc
    {
        public static double converter(string text)
        {
            return Convert.ToDouble(text);

        }

        public static string converters(double text)
        {
            return Convert.ToString(text);

        }
        
        public static string[] split(string text, string[] operetion)
        {

            return text.Split(operetion, StringSplitOptions.RemoveEmptyEntries);

        }
        public static string Containsop(string text, string[] operetion)

        {
            foreach (var in1 in operetion)

            {

                if (text.Contains(in1))
                    return in1;
            }

            return null;
        }

        public static double calculator(string op,double number1,double number2)
        {
            double e=0;

            if (op == "*")

                e= number1 * number2;

            else
            if (op == "/")

                e= number1 / number2;
            else

            if (op == "+")

                e= number1 + number2;
            else

            if (op == "-")

                e= number1 - number2;
            else

            if (op == "%")

                e= (number1 * number2) / 100;


            return e;
        }
    }
}























