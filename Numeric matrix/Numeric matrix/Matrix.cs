using System;

namespace Numeric_matrix
{
    public class Matrix
    {
        private float[,] matrix = new float[0, 0];
        private int row = 0;
        private int column = 0;

        private void FillMatrixZeros(int row, int column)
        {
            float[,] matrix = new float[row, column];
            this.matrix = matrix;
        }

        private float[] FillingArray(float[] numbers)
        {
            Console.WriteLine("Enter the matrix values using Enter:");

            string number = "";

            for (int i = 0; i < row * column; ++i)
            {
                number = Console.ReadLine();
                numbers[i] = Convert.ToInt32(number);
            }

            return numbers;
        }

        private void FillMatrix(float[] numbers)
        {
            int columnSize = 0;
            float[,] newMatrix = new float[row, column];

            for (int i = 0; i < row; i++)
            {
                columnSize = this.column;

                for (int j = 0; j < column; j++)
                {
                    newMatrix[i, j] = numbers[(numbers.Length / this.row * (i + 1)) - columnSize];
                    --columnSize;
                }
            }
            this.matrix = newMatrix;
        }

        public Matrix(int row = 1, int column = 1)
        {
                this.row = row;
                this.column = column;

                FillMatrixZeros(row, column);
        }

        public void Fill()
        {
            float[] numbers = new float[this.row * this.column];

            FillingArray(numbers);

            FillMatrix(numbers);
        }

        public override string ToString()
        {
            string matrixString = "\n";
            string matrixNum = "";

            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    matrixNum += $"{matrix[i, j]}\t";
                }

                matrixString += $"{matrixNum}\n";

                matrixNum = "";
            }

            return matrixString;
        }

        public void SetMatrixIndex(int row, int column, float NewValue)
        {
            this.matrix[row, column] = NewValue;
        }

        public float GetMatrixIndex(int row, int column)
        {
            return this.matrix[row, column];
        }

        public float this[int row, int column]
        {
            get
            {
                return GetMatrixIndex(row, column);
            }

            set
            {
                SetMatrixIndex(row, column, value);
            }
        }

        public static Matrix operator +(Matrix matrixOne, Matrix matrixTwo)
        {
            try
            {

                Matrix newMatrix = matrixOne;

                for (int i = 0; i < matrixOne.row; ++i)
                {
                    for (int j = 0; j < matrixOne.column; ++j)
                    {
                        newMatrix[i, j] += matrixTwo[i, j];
                    }
                }

                return newMatrix;
            }
            catch
            {
                Console.WriteLine("The dimensions of the matrices are not identical");

                return matrixOne;
            }
        }

        public static Matrix operator -(Matrix matrixOne, Matrix matrixTwo)
        {
            try
            {
                Matrix newMatrix = matrixOne;

                for (int i = 0; i < matrixOne.row; ++i)
                {
                    for (int j = 0; j < matrixOne.column; ++j)
                    {
                        newMatrix[i, j] -= matrixTwo[i, j];
                    }
                }


                return newMatrix;
            }
            catch
            {
                Console.WriteLine("The dimensions of the matrices are not identical");

                return matrixOne;
            }
        }

        public static Matrix operator *(Matrix matrixOne, Matrix matrixTwo)
        {
            if (matrixOne.column != matrixTwo.row)
            {
                Console.WriteLine("The number of columns in the first matrix is not equal to the number of rows in the second matrix");

                return matrixOne;
            }
            else
            {

                Matrix NewMatrix = new Matrix(matrixOne.row, matrixTwo.column);

                for (int i = 0; i < matrixOne.row; ++i)
                {
                    for (int j = 0; j < matrixTwo.column; ++j)
                    {
                        for (int k = 0; k < matrixOne.column; ++k)
                        {
                            NewMatrix[i, j] += matrixOne[i, k] * matrixTwo[k, j];
                        }
                    }
                }

                return NewMatrix;
            }
        }
    }
}
