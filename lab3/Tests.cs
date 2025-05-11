using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Tests
    {
        int[] Threads;
        int[] Sizes;
        long[,] Results;

        public enum TestType
        {
            PARALLEL,
            THREAD
        }

        public Tests(int[] threads, int[] sizes)
        {
            Threads = threads;
            Sizes = sizes;
            Results = new long[sizes.Length, threads.Length];
        }

        public void DoTests(int NumTests, TestType type, string FilePath)
        {
            for (int j = 0; j < Sizes.Length; ++j)
            {
                Matrix A = new Matrix(Sizes[j], Sizes[j]);
                Matrix B = new Matrix(Sizes[j], Sizes[j]);
                Matrix result = new Matrix(Sizes[j], Sizes[j]);

                for (int k = 0; k < Threads.Length; ++k)
                {
                    Multiplication mult = new Multiplication(numThreads: Threads[k]);

                    Results[j, k] = 0;

                    for (int i = 0; i < NumTests; ++i)
                    {
                        Stopwatch stopwatch = Stopwatch.StartNew();

                        if (type == TestType.PARALLEL)
                        {
                            //result = mult.MultiplyParallel(A, B);
                            _ = mult.MultiplyParallel(A, B);
                        }
                        if (type == TestType.THREAD)
                        {
                            _ = mult.MultiplyThread(A, B);
                        }

                        stopwatch.Stop();

                        Results[j, k] += stopwatch.ElapsedMilliseconds;
                        //Console.WriteLine($"[{Sizes[j]}, {Threads[k]}, {Results[j, k]}]");

                        A.FillWithRandomValues();
                        B.FillWithRandomValues();
                    }

                    Results[j, k] = Results[j, k] / NumTests;

                }

                A = null;
                B = null;
                result = null;
                GC.Collect();
            }

            using (StreamWriter writer = new StreamWriter(FilePath)) {
                for (int i = 0; i < Results.GetLength(0); ++i)
                {
                    string[] row = new string[Results.GetLength(1)];
                    for (int j = 0; j < Results.GetLength(1); j++)
                    {
                        row[j] = Results[i, j].ToString();
                    }
                    writer.WriteLine(string.Join(",", row));
                }

                Console.WriteLine($"CSV exported to <{FilePath}>");
            
            }


        }

    }
}
