using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Matrix
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public float[,] Values;

        private static Random random = new Random();

        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
            {
                Console.WriteLine("Wymiary muszą być dodatnie! Ustawiono domyślne wymiary 1x1.");
                rows = 1; cols = 1;
            }

            Rows = rows;
            Cols = cols;
            Values = new float[rows, cols];
            FillWithRandomValues();
        }

        public void FillWithRandomValues()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    Values[i, j] = (float)Math.Round(random.NextDouble(), 2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    sb.Append($"{Values[i, j],6:F2} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}
