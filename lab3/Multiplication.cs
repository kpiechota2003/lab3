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

        public Matrix MultiplyParallel(Matrix A, Matrix B)
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

        public Matrix MultiplyThread(Matrix A, Matrix B)
        {
            Matrix result = new Matrix(A.Rows, B.Cols);
            Thread[] threads = new Thread[NumThreads];

            int rowsPerThread = A.Rows / NumThreads;
            int remainingRows = A.Rows % NumThreads;

            for (int t = 0; t < NumThreads; t++)
            {
                int startRow = t * rowsPerThread;
                int endRow;
                if (remainingRows > 0) { endRow = startRow + rowsPerThread + 1;  remainingRows--;  } //distributes remaining rows between threads
                else { endRow = startRow + rowsPerThread;  } //if there no rows to remaining

                threads[t] = new Thread(() =>
                {
                    for (int i = startRow; i < endRow; i++)
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
                    }
                });

                threads[t].Start();
            }

            //wait for all threads to finish
            for (int t = 0; t < NumThreads; t++)
            {
                threads[t].Join();
            }

            return result;
        }


    }


}
