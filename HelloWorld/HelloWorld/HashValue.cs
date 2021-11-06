using System.Text;
using System;

namespace HelloWorld
{
    public class HashValue
    {

        public int CalculateHashValue (string text) {
            int hashValue = 0;
            if (text.Length > 0)
            {
                char[] splitText = text.ToCharArray();
                string letter;
                int number;
                
                for (int x=0;x< text.Length;x++) {
                    letter = splitText[x].ToString();
                    byte[] asciiBytes = Encoding.ASCII.GetBytes(letter);
                    number = System.Int32.Parse(asciiBytes[0].ToString()) ;
                    hashValue = hashValue + number;

                }

                hashValue = hashValue % 127;
            }
            else {
                hashValue = -1;
            }
            return hashValue;
        }
       
    }
}
