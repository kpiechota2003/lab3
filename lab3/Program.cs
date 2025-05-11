using System.Diagnostics;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Threads = { 1, 2, 3, 4 };
            int[] Sizes = { 100, 220, 500 };

            Tests T = new Tests(Threads, Sizes);
            T.DoTests(3, Tests.TestType.PARALLEL, "C:\\Users\\user1\\Desktop\\NET_lab3\\parallel.csv");
            T.DoTests(3, Tests.TestType.THREAD, "C:\\Users\\user1\\Desktop\\NET_lab3\\thread.csv");
        }
    }
}
