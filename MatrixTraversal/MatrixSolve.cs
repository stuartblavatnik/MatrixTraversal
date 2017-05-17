using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MatrixTraversal
{
    public class MatrixSolve
    {
        private char[,] myMatrix = null;

        private Point myCurrentPosition = new Point(-1, -1);
        private List<Point> myDeadEnds = new List<Point>();
        private List<Point> myCurrentPath = new List<Point>();

        private bool myFound = false;

        public MatrixSolve(char[,] theMatrix)
        {
            if (theMatrix == null)
            {
                throw new ApplicationException("Matix must not be null");
            }
            else if (theMatrix.GetLength(0) != theMatrix.GetLength(1))
            {
                throw new ApplicationException("Matrix must be square");
            }


            myMatrix = theMatrix;
        }

        public string Solve()
        {
            string solveResult = string.Empty;

            if (myMatrix == null)
            {
                solveResult = "Null matrix";
            }
            else if (myMatrix.Length == 0)
            {
                solveResult = "Empty matrix";
            }
            else
            {

                solveResult = ProcessMatrix();
            }


            return solveResult;
        }

        private string ProcessMatrix()
        {
            for (int currentY = 0; currentY < myMatrix.GetLength(0); ++currentY)
            {
                for (int currentX = 0; currentX < myMatrix.GetLength(1); ++currentX)
                {
                    myCurrentPosition.Y = currentY;
                    myCurrentPosition.X = currentX;

                    if (myMatrix[myCurrentPosition.Y, myCurrentPosition.X] != 'x')
                    {
                        if (!myDeadEnds.Contains(myCurrentPosition))
                        {
                            myCurrentPath = new List<Point>();
                            myCurrentPath.Add(myCurrentPosition);
                            if (TraverseMatrix())
                            {
                                return "Success: " + PathToString();
                            }
                            else
                            {
                                Console.WriteLine("Failed path: " + PathToString());
                            }
                        }
                    }
                }
            }

            return "Failure";
        }

        private string PathToString()
        {
            StringBuilder pathToString = new StringBuilder();

            foreach (Point p in myCurrentPath)
            {
                if (pathToString.Length != 0 )
                {
                    pathToString.Append(", ");
                }
                pathToString.Append(p.ToString());
            }

            return pathToString.ToString();
        }

        private bool TraverseMatrix()
        {
 
            switch(myMatrix[myCurrentPosition.Y, myCurrentPosition.X])
            {
                case 'u':
                    if (MoveUp())
                    {
                        TraverseMatrix();
                    }
                    break;
                case 'd':
                    if (MoveDown())
                    {
                        TraverseMatrix();
                    }
                    break;
                case 'l':
                    if (MoveLeft())
                    {
                        TraverseMatrix();
                    }
                    break;
                case 'r':
                    if (MoveRight())
                    {
                        TraverseMatrix();
                    }
                    break;
                case 'x':
                    myFound = true;
                    return true;
                default:
                    return false;
            }
            if (myFound)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool MoveUp()
        {
            if (myCurrentPosition.Y - 1 == -1)
            {
                myCurrentPosition.Y = myMatrix.GetLength(0) - 1;
            }
            else
            {
                myCurrentPosition.Y -= 1;
            }

            if (IveBeenHereBefore())
            {
                AddToDeadEnds();
                return false;
            }
            else
            {
                AddToPath();
            }
            return true;
        }

        private bool MoveDown()
        {
            if (myCurrentPosition.Y + 1 == myMatrix.GetLength(0))
            {
                myCurrentPosition.Y = 0;
            }
            else
            {
                myCurrentPosition.Y += 1;
            }

            if (IveBeenHereBefore())
            {
                AddToDeadEnds();
                return false;
            }
            else
            {
                AddToPath();
            }
            return true;
        }

        private bool MoveLeft()
        {
            if (myCurrentPosition.X - 1 == -1)
            {
                myCurrentPosition.X = myMatrix.GetLength(1) - 1;
            }
            else
            {
                myCurrentPosition.X -= 1;
            }

            if (IveBeenHereBefore())
            {
                AddToDeadEnds();
                return false;
            }
            else
            {
                AddToPath();
            }
            return true;
        }

        private bool MoveRight()
        {
            if (myCurrentPosition.X + 1 == myMatrix.GetLength(1))
            {
                myCurrentPosition.X = 0;
            }
            else
            {
                myCurrentPosition.X += 1;
            }

            if (IveBeenHereBefore())
            {
                AddToDeadEnds();
                return false;
            }
            else
            {
                AddToPath();
            }
            return true;
        }


        private void AddToPath()
        {
            myCurrentPath.Add(myCurrentPosition);
        }

        private bool IveBeenHereBefore()
        {
            return myCurrentPath.Contains(myCurrentPosition);
        }

        private void AddToDeadEnds()
        {
            foreach (Point p in myCurrentPath)
            {
                if (!myDeadEnds.Contains(p))
                {
                    myDeadEnds.Add(p);
                }
            }
        }
    }
}
