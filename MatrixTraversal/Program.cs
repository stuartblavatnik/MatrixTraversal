using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix =
            {
                { 'u', 'd', 'l', 'r', 'l' },
                { 'l', 'd', 'r', 'u', 'r' },
                { 'd', 'd', 'x', 'l', 'l' },
                { 'u', 'd', 'l', 'd', 'u' },
                { 'l', 'd', 'r', 'd', 'u' }
            };


            char[,] matrix2 =
{
                { 'u', 'd', 'l', 'r', 'l' },
                { 'l', 'd', 'r', 'u', 'r' },
                { 'd', 'd', 'd', 'l', 'l' },
                { 'u', 'd', 'l', 'd', 'u' },
                { 'l', 'd', 'r', 'd', 'u' }
            };

            MatrixSolve ms = new MatrixSolve(matrix2);
            String result = ms.Solve();

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
