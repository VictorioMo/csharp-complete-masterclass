using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class CommentsAndDocumentation
    {
        /* Always specify WHY and BECAUSE when describing your code */

        // bad example:

        /* This function performs the factorial of a number */
        // this is already understandable from it's name

        // good example:
        /* Using recursion BECAUSE it's more intuitive */
        // this explains WHY you did so


        public double Factorial(double number)
        {
            double result;

            /* Code[..] */
            result = Factorial(number - 1);
            /* [..]Code */

            return result;
        }

        /* Writing TODOs */

        // TODO: Implement the binary search algorithm

        public int BinarySearch()
        {
            return -1;
        }

        /* Also in Visual Studio you can view all TODOs by accesing View -> Task List*/

        // When documenting code, use this:

        ///<summary>
        ///
        /// </summary>
        /// 

        // This is used to explain what the function, class or property does,
        // and it will also appear when hovering with the mouse

        // ex:
        /// <summary>
        /// Calculates the square root of a given number x, and returns the result.
        /// </summary>
        /// <param name="x"> The number of which the square root shall be calculated. </param>
        /// <returns>Returns the square root of x.</returns>
        public double SquareRoot(double x)
        {
            //code
            return 0;
        }
    }
}
