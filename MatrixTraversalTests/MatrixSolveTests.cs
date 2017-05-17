using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixTraversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTraversal.Tests
{
    [TestClass()]
    public class MatrixSolveTests
    {
        [TestMethod()]
        public void MatrixSolveTestConstructor()
        {
          char[,] matrix =
          {
                { 'u', 'd', 'l', 'r', 'l' },
                { 'l', 'd', 'r', 'u', 'r' },
                { 'd', 'd', 'x', 'l', 'l' },
                { 'u', 'd', 'l', 'd', 'u' },
                { 'l', 'd', 'r', 'd', 'u' }
            };

            MatrixSolve ms = new MatrixSolve(matrix); //comment

            Assert.IsNotNull(ms);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "Matrix must be square")]
        public void MatrixSolveTestConstructorNonSquare()
        {
            char[,] matrix =
            {
                { 'u', 'd', 'l', 'r', 'l' },
                { 'l', 'd', 'r', 'u', 'r' },
                { 'd', 'd', 'x', 'l', 'l' },
            };

            MatrixSolve ms = new MatrixSolve(matrix);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "Matix must not be null")]
        public void MatrixSolveTestConstructorNullMatrix()
        {
            char[,] matrix = null;
          

            MatrixSolve ms = new MatrixSolve(matrix);
        }

        [TestMethod()]
        public void SolveTestPositive()
        {
            char[,] matrix =
              {
                { 'u', 'd', 'l', 'r', 'l' },
                { 'l', 'd', 'r', 'u', 'r' },
                { 'd', 'd', 'x', 'l', 'l' },
                { 'u', 'd', 'l', 'd', 'u' },
                { 'l', 'd', 'r', 'd', 'u' }
            };

            MatrixSolve ms = new MatrixSolve(matrix);
            String result = ms.Solve();

            Assert.AreEqual(result, "Success: {X=0,Y=0}, {X=0,Y=4}, {X=4,Y=4}, {X=4,Y=3}, {X=4,Y=2}, {X=3,Y=2}, {X=2,Y=2}");
        }

        [TestMethod()]
        public void SolveTestNegative()
        {
            char[,] matrix =
              {
                
                { 'u', 'd', 'l', 'r', 'l' },
                { 'l', 'd', 'r', 'u', 'r' },
                { 'd', 'd', 'd', 'l', 'l' },
                { 'u', 'd', 'l', 'd', 'u' },
                { 'l', 'd', 'r', 'd', 'u' }
            };

            MatrixSolve ms = new MatrixSolve(matrix);
            String result = ms.Solve();

            Assert.AreEqual(result, "Failure");
        }

    }
}