using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Matrix
{
    /// <summary>
    /// Given a square matrix the task is that we turn it by 180 degrees in anti-clockwise direction without using any extra space
    /// Examples:
    /// 
    /// Input :  
    /// 1  2  3
    /// 4  5  6
    /// 7  8  9
    /// Output : 
    /// 9 8 7 
    /// 6 5 4 
    /// 3 2 1
    /// Input :  
    /// 1 2 3 4 
    /// 5 6 7 8 
    /// 9 0 1 2 
    /// 3 4 5 6 
    /// Output : 
    /// 6 5 4 3 
    /// 2 1 0 9 
    /// 8 7 6 5 
    /// 4 3 2 1
    /// https://www.geeksforgeeks.org/rotate-matrix-180-degree/
    /// </summary>
    public static class Rotate180Matrix
    {
        /// <summary>
        /// There are four steps :
        /// 1- Find transpose of matrix.
        /// 2- Reverse columns of the transpose.
        /// 3- Find transpose of matrix.
        /// 4- Reverse columns of the transpose
        /// 
        /// Let the given matrix be
        /// 00 10 20
        /// 01 11 21
        /// 02 12 22
        /// 
        /// First we find transpose.
        /// 00 01 02
        /// 10 11 12
        /// 20 21 22
        /// 
        /// Then we reverse elements of every column.
        /// 02 01 00
        /// 12 11 10
        /// 22 21 20
        /// 
        /// then transpose again
        /// 02 12 22
        /// 01 11 21
        /// 00 10 20
        /// 
        /// Then we reverse elements of every column again
        /// 22 12 02
        /// 21 11 01
        /// 20 10 00
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="size"></param>
        private static void ReverseColumns(int[][] arr, int size)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0, k = size - 1; j < k; j++, k--)
                    swap(arr[j][i], arr[k][i]);
        }

        // Function for transpose of matrix
        private static void Transpose(int[][] arr, int size)
        {
            for (int i = 0; i < size; i++)
                for (int j = i; j < size; j++)
                    swap(arr[i][j], arr[j][i]);
        }

        // Function for display the matrix
        private static void PrintMatrix(int[][] arr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(arr[i][j] + " ");
                Console.Write("\n");
            }
        }

        // Function to anticlockwise rotate matrix
        // by 180 degree
        private static void Rotate180(int[][] arr)
        {
            Transpose(arr, 4);
            ReverseColumns(arr, 4);
            Transpose(arr, 4);
            ReverseColumns(arr, 4);
        }

        private static void swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
