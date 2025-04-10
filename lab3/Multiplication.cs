using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Multiplication
    {
        public int NumThreads { get; private set; }

        public Multiplication(int numThreads)
        {
            if (numThreads <= 0)
            {
                Console.WriteLine("Ilość wątków musi być dodatnia! Ustawiono wartość domyślną 1.");
                numThreads = 1;
            }
                
            NumThreads = numThreads;
        }

        public Matrix Multiply(Matrix A, Matrix B)
        {
            if (A.Cols != B.Rows) return A;
            Matrix result = new Matrix(A.Rows, B.Cols);

            var opt = new ParallelOptions { MaxDegreeOfParallelism = NumThreads };

            Parallel.For(0, A.Rows, opt, i =>
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    float sum = 0;
                    for (int k = 0; k < A.Cols; k++)
                    {
                        sum += A.Values[i, k] * B.Values[k, j];
                    }
                    result.Values[i, j] = sum;
                }
            });

            return result;
        }



    }


}
