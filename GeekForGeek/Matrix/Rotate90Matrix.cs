using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Matrix
{
    /// <summary>
    /// Given an square matrix, turn it by 90 degrees in anti-clockwise direction without using any extra space.
    /// Input
    /// 00 10 20
    /// 01 11 21
    /// 02 12 22
    /// 
    /// Output:
    /// 20 21 22
    /// 10 11 12
    /// 00 01 02
    /// 
    /// Input:
    /// 1  2  3  4 
    /// 5  6  7  8 
    /// 9 10 11 12
    /// 13 14 15 16 
    /// 
    /// Output:
    /// 4  8 12 16 
    /// 3  7 11 15 
    /// 2  6 10 14 
    /// 1  5  9 13
    /// </summary>
    public static class Rotate90Matrix
    {
        /// <summary>
        /// The idea is for each square cycle, we swap the elements involved with the corresponding cell in the matrix in anti-clockwise direction 
        /// i.e. from top to left, left to bottom, bottom to right and from right to top one at a time. 
        /// We use nothing but a temporary variable to achieve this.
        /// Below steps demonstrate the idea
        /// 
        /// First Cycle(Involves Red Elements)
        /// 1  2  3 4 
        /// 5  6  7  8 
        /// 9 10 11 12 
        /// 13 14 15 16 
        /// 
        /// Moving first group of four elements(First
        /// elements of 1st row, last row, 1st column
        /// and last column) of first cycle in counter clockwise.
        /// 4  2  3 16
        /// 5  6  7 8 
        /// 9 10 11 12 
        /// 1 14  15 13 
        /// 
        /// Moving next group of four elements of first cycle in counter clockwise 
        /// 4  8  3 16 
        /// 5  6  7  15  
        /// 2  10 11 12 
        /// 1  14  9 13 
        /// 
        /// Moving final group of four elements of first cycle in counter clockwise 
        /// 4  8 12 16 
        /// 3  6  7 15 
        /// 2 10 11 14 
        /// 1  5  9 13 
        /// 
        /// Second Cycle (Involves Blue Elements)
        /// 4  8 12 16 
        /// 3  6 7  15 
        /// 2  10 11 14 
        /// 1  5  9 13 
        /// 
        /// Fixing second cycle
        /// 4  8 12 16 
        /// 3  7 11 15 
        /// 2  6 10 14 
        /// 1  5  9 13
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="N"></param>
        private static void Rotate(int[][] mat, int N)
        {
            for (int x = 0; x < N / 2; x++)
            {
                // Consider elements in group of 4 in 
                // current square
                for (int y = x; y < N - x - 1; y++)
                {
                    // store current cell in temp variable
                    int temp = mat[x][y];
                    Console.Write("\n------------------");
                    Console.Write("\nx: " + x + ", y:" + y);
                    // move values from right to top
                    mat[x][y] = mat[y][N - 1 - x];
                    Console.Write("\nAssign[" + y + "][" + (N - 1 - x) + "] to [" + x + "][" + y + "]");

                    // move values from bottom to right
                    mat[y][N - 1 - x] = mat[N - 1 - x][N - 1 - y];
                    Console.Write("\nAssign[" + (N - 1 - x) + "][" + (N - 1 - y) + "] to [" + y + "][" + (N - 1 - x) + "]");

                    // move values from left to bottom
                    mat[N - 1 - x][N - 1 - y] = mat[N - 1 - y][x];
                    Console.Write("\nAssign[" + (N - 1 - y) + "][" + (x) + "] to [" + (N - 1 - x) + "][" + (N - 1 - y) + "]");

                    // assign temp to left
                    mat[N - 1 - y][x] = temp;
                    Console.Write("\nAssign[" + x + "][" + y + "] to [" + (N - 1 - y) + "][" + x + "]");
                }
            }
        }

        // Function to print the matrix
        private static void DisplayMatrix(int N, int[][] mat)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" " + mat[i][j]);

                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public static void Test()
        {
            int N = 4;

            // Test Case 1
            int[][] mat = new int[][]
            {
                new int[]{1, 2, 3, 4},
                new int[]{5, 6, 7, 8},
                new int[]{9, 10, 11, 12},
                new int[]{13, 14, 15, 16}
            };

            Rotate(mat, N);

            // Print rotated matrix
            DisplayMatrix(N, mat);
        }
    }
}
