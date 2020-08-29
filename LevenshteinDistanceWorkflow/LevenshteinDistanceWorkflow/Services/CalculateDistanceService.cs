using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevenshteinDistanceWorkflow.Services
{
    public class CalculateDistanceService
    {
        /// <summary>
        /// Compute the distance between given words
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Compute(string source, string target)
        {
            try
            {
                // If any word is empty, return the other word's length as result
                if (source.Length == 0)
                {
                    return target.Length;
                }

                if (target.Length == 0)
                {
                    return source.Length;
                }

                // Assign incremental values (starting from 1) for first row and first column cells in the matrix
                var matrix = new int[source.Length + 1, target.Length + 1];
                for (var i = 0; i <= source.Length; i++)
                {
                    matrix[i, 0] = i;
                }

                for (var j = 0; j <= target.Length; j++)
                {
                    matrix[0, j] = j;
                }

                // Outer loop to iterate through first word's letters
                for (var i = 1; i <= source.Length; i++)
                {
                    //Inner loop to iterate through second word's letters
                    for (var j = 1; j <= target.Length; j++)
                    {
                        // If letters match in both words, then cost is 0, otherwise its 1
                        var cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                        // Find the minimum value among three cells and add cost to it
                        // Three cells are the Left, Top and Top-Left Diagonal cells to the current cell
                        matrix[i, j] = Math.Min(
                            Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                            matrix[i - 1, j - 1] + cost);
                    }
                }

                return matrix[source.Length, target.Length];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}