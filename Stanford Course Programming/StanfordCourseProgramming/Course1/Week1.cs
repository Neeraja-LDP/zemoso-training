using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course1
{
    internal class Week1
    {
        public static void Main(string[] args)
        {
            string num1 = "3141592653589793238462643383279502884197169399375105820974944592";
            string num2 = "2718281828459045235360287471352662497757247093699959574966967627";

            // Testing with smaller numbers
            //string num1 = "5678";
            //string num2 = "1234";

            string result = KaratsubaMultiply(num1, num2);
            Console.WriteLine(result);
        }

        public static string KaratsubaMultiply(string x, string y)
        {
            // Base case for recursion
            if (x.Length == 1 && y.Length == 1)
            {
                return (int.Parse(x) * int.Parse(y)).ToString();
            }

            // Make lengths of both numbers equal by padding with leading zeros on the left
            int maxLength = Math.Max(x.Length, y.Length);
            x = x.PadLeft(maxLength, '0');
            y = y.PadLeft(maxLength, '0');

            int n = maxLength;
            int half = n / 2;

            // Split x and y into two halves
            string x1 = x.Substring(0, n - half);
            string x0 = x.Substring(n - half, half);
            string y1 = y.Substring(0, n - half);
            string y0 = y.Substring(n - half, half);

            // Recursively calculate three products
            // Step 1: a * c
            // Step 2: b * d
            // Step 3: (a + b)*(c + d)
            // Step 4: (Step 3) - (Step 2) - (Step 1)
            // Step 5: take the result of Step 1 and Step 4 and pad it with zeroes. Add
            //         this to the value of Step 2.
            string z2 = KaratsubaMultiply(x1, y1);
            string z0 = KaratsubaMultiply(x0, y0);
            string z1 = KaratsubaMultiply(AddStrings(x1, x0), AddStrings(y1, y0));
            z1 = SubtractStrings(SubtractStrings(z1, z2), z0);

            // Combine the results
            string result = AddStrings(AddStrings(PadZeros(z2, 2 * half), PadZeros(z1, half)), z0);
            return result.TrimStart('0');
        }

        /**
         * Method to add two strings containing numbers together 
         */
        private static string AddStrings(string num1, string num2)
        {
            // Ensuring that the numbers are of equal length
            int maxLength = Math.Max(num1.Length, num2.Length);
            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');


            int carry = 0;
            string result = string.Empty;
            for (int i = maxLength - 1; i >= 0; i--)
            {
                int sum = (num1[i] - '0') + (num2[i] - '0') + carry;

                // Calculating the next carry
                carry = sum / 10;

                // Appending the number to result
                result = (sum % 10).ToString() + result;
            }

            // When the end of the calculations is reached and there is a carry left over
            if (carry > 0)      
            {
                result = carry.ToString() + result;
            }

            return result;
        }

        /**
         * Method to subtract two strings containing numbers
        */
        private static string SubtractStrings(string num1, string num2)
        {
            // Ensuring that the numbers are of equal length
            int maxLength = Math.Max(num1.Length, num2.Length);
            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');


            int borrow = 0;
            string result = string.Empty;
            for (int i = maxLength - 1; i >= 0; i--)
            {
                int diff = (num1[i] - '0') - (num2[i] - '0') - borrow;
                // If the difference is less than zero, borrow a 1
                if (diff < 0)
                {
                    diff += 10;
                    borrow = 1;
                }
                else    // If there is nothing to borrow, set borrow to 0
                {
                    borrow = 0;
                }

                // Append the difference to the result
                result = diff.ToString() + result;
            }
            return result.TrimStart('0');
        }

        /**
         * Method to pad a string with zeroes to the right
         */
        private static string PadZeros(string num, int zeros)
        {
            string padding = new('0', zeros);
            return num + padding;
        }
    }
}

