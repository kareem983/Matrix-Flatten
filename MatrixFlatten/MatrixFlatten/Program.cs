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
            testMatrixFunctions();
        }

        #region MATRIX FUNCTIONS
        static void userInput()
        {
            Console.WriteLine("Enter The number of Rows for 3d Array: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The number of Columns for 3d Array: ");
            m = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The number of Cells in each Cell for 3d Array: ");
            p = int.Parse(Console.ReadLine());
            arr_3D = new int[n, m, p];
            Console.WriteLine("\n======================================================================");

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine($"The Row number {i + 1}, The Column number: {j + 1}, Enter The Values of this Cell: ");
                    for (int k = 0; k < p; k++)
                        arr_3D[i, j, k] = int.Parse(Console.ReadLine());
                }
            Console.WriteLine("======================================================================");
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

        static int getMirrorIndex(int i, int j, int k)
        {
            return (i * m * p) + (j * p) + k;
        }

        static void testMatrixFunctions()
        {
            // this to make sure that the 1DArray is Created Successfully
            Console.Write("\n\n### 1D Array Created Successfully ###\nThe 1D Array Values: ");
            for (int y = 0; y < (n * m * p); y++)
                Console.Write(arr_1D[y] + " ");


            // this to make sure that the mirror index is true
            char cohice = 'n';
            do
            {
                Console.WriteLine("\n\n______________________________________________________________________");
                Console.WriteLine("Enter The Indices of 3D Array to get the Mirror Index from 1D Array");
                int testI_index, testJ_index, testK_index;
                Console.WriteLine("Enter The index I in 3d Array: ");
                testI_index = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter The index J in 3d Array: ");
                testJ_index = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter The index K in 3d Array: ");
                testK_index = int.Parse(Console.ReadLine());

                try
                {
                    if (testI_index >= n || testJ_index >= m || testK_index >= p) throw new Exception();

                    int MirrorIndex = getMirrorIndex(testI_index, testJ_index, testK_index);
                    Console.WriteLine("The Mirror index from 1D Array: " + MirrorIndex);
                    Console.WriteLine($"The Value of Mirror index [{MirrorIndex}] from 1D Array: " + arr_1D[MirrorIndex]);
                    Console.WriteLine($"The Value of index [{testI_index}, {testJ_index}, {testK_index}] from 3D Array: "
                        + arr_3D[testI_index, testJ_index, testK_index]);
                }
                catch
                {
                    Console.WriteLine($"Please Enter Indexes in range of 3D Array I[0-{n - 1}], J[0-{m - 1}], K[0-{p - 1}]!!!");
                }
                Console.WriteLine("______________________________________________________________________");
                Console.WriteLine("\nDo you want to test another test(y/n)");
                cohice = char.Parse(Console.ReadLine());

            } while (cohice == 'y' || cohice == 'Y');
        }
        #endregion

    }
}
