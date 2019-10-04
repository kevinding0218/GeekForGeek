﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Strings
{
    /// <summary>
    /// Given a string, a partitioning of the string is a palindrome partitioning if every substring of the partition is a palindrome. 
    /// For example, “aba|b|bbabb|a|b|aba” is a palindrome partitioning of “ababbbabbababa”. 
    /// Determine the fewest cuts needed for palindrome partitioning of a given string. 
    /// For example, minimum 3 cuts are needed for “ababbbabbababa”. The three cuts are “a|babbbab|b|ababa”. 
    /// If a string is palindrome, then minimum 0 cuts are needed. 
    /// If a string of length n containing all different characters, then minimum n-1 cuts are needed
    /// 
    /// If the string is a palindrome, then we simply return 0. Else, like the Matrix Chain Multiplication problem, 
    /// we try making cuts at all possible places, recursively calculate the cost for each cut and return the minimum value.
    /// Let the given string be str and minPalPartion() be the function that returns the fewest cuts needed for palindrome partitioning.
    /// following is the optimal substructure property.
    /// // i is the starting index and j is the ending index. i must be passed as 0 and j as n-1    
    /// minPalPartion(str, i, j) = 0 if i == j. // When string is of length 1.
    /// minPalPartion(str, i, j) = 0 if str[i..j] is palindrome.
    /// //If none of the above conditions is true, then minPalPartion(str, i, j) can be 
    /// //calculated recursively using the following formula.
    /// minPalPartion(str, i, j) = Min { minPalPartion(str, i, k) + 1 +
    /// minPalPartion(str, k+1, j) }
    /// where k varies from i to j-1
    /// Following is Dynamic Programming solution. 
    /// It stores the solutions to subproblems in two arrays P[][] and C[][], and reuses the calculated values
    /// </summary>
    public static class PalindromePartitionBreak
    {
        // Returns the minimum number of cuts needed 
        // to partition a string such that every 
        // part is a palindrome 
        static int minPalPartion(String str)
        {
            // Get the length of the string 
            int n = str.Length;

            /* Create two arrays to build the solution 
            in bottom up manner 
            C[i][j] = Minimum number of cuts needed  
                        for palindrome partitioning 
                        of substring str[i..j] 
            P[i][j] = true if substring str[i..j] is 
                        palindrome, else false 
            Note that C[i][j] is 0 if P[i][j] is true 
            */
            int[,] C = new int[n, n];
            bool[,] P = new bool[n, n];

            int i, j, k, L; // different looping variables 

            // Every substring of length 1 is a palindrome 
            for (i = 0; i < n; i++)
            {
                P[i, i] = true;
                C[i, i] = 0;
            }

            /* L is substring length. Build the solution in 
            bottom up manner by considering all substrings 
            of length starting from 2 to n. The loop  
            structure is same as Matrx Chain Multiplication 
            problem ( 
            See https:// www.geeksforgeeks.org/matrix-chain-multiplication-dp-8/ )*/
            for (L = 2; L <= n; L++)
            {
                // For substring of length L, set different 
                // possible starting indexes 
                for (i = 0; i < n - L + 1; i++)
                {
                    j = i + L - 1; // Set ending index 

                    // If L is 2, then we just need to 
                    // compare two characters. Else need to 
                    // check two corner characters and value 
                    // of P[i+1][j-1] 
                    if (L == 2)
                        P[i, j] = (str[i] == str[j]);
                    else
                        P[i, j] = (str[i] == str[j]) && P[i + 1, j - 1];

                    // IF str[i..j] is palindrome, then 
                    // C[i][j] is 0 
                    if (P[i, j] == true)
                        C[i, j] = 0;
                    else
                    {
                        // Make a cut at every possible 
                        // localtion starting from i to j, 
                        // and get the minimum cost cut. 
                        C[i, j] = int.MaxValue;
                        for (k = i; k <= j - 1; k++)
                            C[i, j] = Math.Min(C[i, j], C[i, k]
                                                            + C[k + 1, j] + 1);
                    }
                }
            }

            // Return the min cut value for complete 
            // string. i.e., str[0..n-1] 
            return C[0, n - 1];
        }

        public static void Test()
        {
            String str = "ababbbabbababa";
            Console.Write($"Min cuts needed for Palindrome Partitioning is {minPalPartion(str)}");
        }
    }
}
