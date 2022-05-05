using System;

namespace MatrixFlatten
{
    class Program
    {
        static int [] arr_1D;
        static int[ , , ] arr_3D;
        static int n, m, p, q;

        static void Main(string[] args)
        {
            userInput();
            create1DArray();
        }


        #region MATRIX FUNCTIONS
        static void userInput()
        {
            Console.WriteLine("Enter The number of Rows for 3d Array");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The number of Columns for 3d Array");
            m = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The number of Cells in each Cell for 3d Array");
            p = int.Parse(Console.ReadLine());
            arr_3D = new int[n, m, p];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine($"The Row number {i + 1}, The Column number: {j + 1}, Enter The Values of this Cell");
                    for (int k = 0; k < p; k++)
                        arr_3D[i, j, k] = int.Parse(Console.ReadLine());
                }
        }

        static void create1DArray()
        {
            int y = 0;
            q = n * m * p;
            arr_1D = new int[q];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    for (int k = 0; k < p; k++)
                        arr_1D[y++] = arr_3D[i, j, k];
        }
        #endregion
    
    }
}
