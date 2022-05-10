using System;

namespace MatrixFlatten
{
    class Program
    {
        static int [] arr_1D;
        static int[ , , ] arr_3D;
        static int rows_3dArr, cols_3dArr, size_thirdD3dArr, size_1dArr;

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
            rows_3dArr = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The number of Columns for 3d Array: ");
            cols_3dArr = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The number of Cells in each Cell for 3d Array: ");
            size_thirdD3dArr = int.Parse(Console.ReadLine());
            arr_3D = new int[rows_3dArr, cols_3dArr, size_thirdD3dArr];
            Console.WriteLine("\n======================================================================");

            for (int i = 0; i < rows_3dArr; i++)
                for (int j = 0; j < cols_3dArr; j++)
                {
                    Console.WriteLine($"The Row number {i + 1}, The Column number: {j + 1}, Enter The Values of this Cell: ");
                    for (int k = 0; k < size_thirdD3dArr; k++)
                        arr_3D[i, j, k] = int.Parse(Console.ReadLine());
                }
            Console.WriteLine("======================================================================");
        }

        static void create1DArray()
        {
            int y = 0;
            size_1dArr = rows_3dArr * cols_3dArr * size_thirdD3dArr;
            arr_1D = new int[size_1dArr];

            for (int i = 0; i < rows_3dArr; i++)
                for (int j = 0; j < cols_3dArr; j++)
                    for (int k = 0; k < size_thirdD3dArr; k++)
                        arr_1D[y++] = arr_3D[i, j, k];
        }

        static int getMirrorIndex(int index_1dim, int index_2dim, int index_3dim)
        {
            // getMirrorIndex: take indices of 3D Array and return the mirror index from 1d Array, Using the below Equation.
            return (index_1dim * cols_3dArr * size_thirdD3dArr) + (index_2dim * size_thirdD3dArr) + index_3dim;
        }

        static void testMatrixFunctions()
        {
            // this to make sure that the 1DArray is Created Successfully
            Console.Write("\n\n### 1D Array Created Successfully ###\nThe 1D Array Values: ");
            for (int y = 0; y < (rows_3dArr * cols_3dArr * size_thirdD3dArr); y++)
                Console.Write(arr_1D[y] + " ");


            // this to make sure that the mirror index is true
            char cohice = 'n';
            do
            {
                Console.WriteLine("\n\n______________________________________________________________________");
                Console.WriteLine($"Enter The Indices of 3D Array in ranges I[0-{rows_3dArr - 1}], J[0-{cols_3dArr - 1}], K[0-{size_thirdD3dArr - 1}]\nto get the Mirror Index from 1D Array");
                int testI_index, testJ_index, testK_index;
                Console.WriteLine("Enter The index I in 3d Array: ");
                testI_index = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter The index J in 3d Array: ");
                testJ_index = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter The index K in 3d Array: ");
                testK_index = int.Parse(Console.ReadLine());

                try
                {
                    if (testI_index < 0  || testI_index >= rows_3dArr ||
                        testJ_index < 0  || testJ_index >= cols_3dArr ||
                        testK_index < 0  || testK_index >= size_thirdD3dArr) throw new Exception();

                    int MirrorIndex = getMirrorIndex(testI_index, testJ_index, testK_index);
                    Console.WriteLine("The Mirror index from 1D Array: " + MirrorIndex);
                    Console.WriteLine($"The Value of Mirror index [{MirrorIndex}] from 1D Array: " + arr_1D[MirrorIndex]);
                    Console.WriteLine($"The Value of index [{testI_index}, {testJ_index}, {testK_index}] from 3D Array: "
                        + arr_3D[testI_index, testJ_index, testK_index]);
                }
                catch
                {
                    Console.WriteLine($"Please Enter Indexes in range of 3D Array I[0-{rows_3dArr - 1}], J[0-{cols_3dArr - 1}], K[0-{size_thirdD3dArr - 1}]!!!");
                }
                Console.WriteLine("______________________________________________________________________");
                Console.WriteLine("\nDo you want to test another test(y/n)");
                cohice = char.Parse(Console.ReadLine());

            } while (cohice == 'y' || cohice == 'Y');
        }
        #endregion

    }
}
