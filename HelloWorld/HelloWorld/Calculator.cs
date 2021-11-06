using System;
namespace HelloWorld
{
    public class Calculator
    {
        public static int result;

        public int Multiplication(int a, int b){
            result = a * b;
                return result;
        }

        public int Division(int a, int b) {

            result = -9999;

            if (b <= 0)
            {
                Console.WriteLine("The second number could not be 0");
            }
            else { result = a / b;  }

            return result;

        }
    }
}
