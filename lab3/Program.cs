using System.Diagnostics;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix A = new Matrix(500, 300);
            Matrix B = new Matrix(300, 400);

            Multiplication mult = new Multiplication(numThreads: 4);

            Stopwatch stopwatch = Stopwatch.StartNew();

            Matrix result = mult.Multiply(A, B);

            stopwatch.Stop();
            Console.WriteLine($"Mnożenie zajęło: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
