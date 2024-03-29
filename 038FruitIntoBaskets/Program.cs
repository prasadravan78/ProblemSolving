﻿namespace _038FruitIntoBaskets
{
    /*
    You are visiting a farm that has a single row of fruit trees arranged from left to right. The trees are represented by an integer array 
    fruits where fruits[i] is the type of fruit the ith tree produces.
    You want to collect as much fruit as possible. However, the owner has some strict rules that you must follow:
    You only have two baskets, and each basket can only hold a single type of fruit. There is no limit on the amount of fruit each basket can hold.
    Starting from any tree of your choice, you must pick exactly one fruit from every tree (including the start tree) while moving to the right.
    The picked fruits must fit in one of your baskets.
    Once you reach a tree with fruit that cannot fit in your baskets, you must stop.
    Given the integer array fruits, return the maximum number of fruits you can pick.

    Example 1:
    Input: fruits = [1,2,1]
    Output: 3
    Explanation: We can pick from all 3 trees.

    Example 2:
    Input: fruits = [0,1,2,2]
    Output: 3
    Explanation: We can pick from trees [1,2,2].
    If we had started at the first tree, we would only pick from trees [0,1].

    Example 3:
    Input: fruits = [1,2,3,2,2]
    Output: 4
    Explanation: We can pick from trees [2,3,2,2].
    If we had started at the first tree, we would only pick from trees [1,2]. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TotalFruit(new int[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 }));
            Console.ReadLine();
        }

        public static int TotalFruit(int[] fruits)
        {
            if (fruits.Length == 0)
            {
                return 0;
            }

            int fruit1 = fruits[0];
            int fruit2 = -1;
            int response = 1;
            int current = 1;
            int start = 0;

            for (int i = 1; i < fruits.Length; i++)
            {
                if (fruits[i] == fruit1 || fruits[i] == fruit2)
                {
                    current++;
                }
                else
                {
                    response = Math.Max(response, current);
                    fruit1 = fruits[i - 1];
                    fruit2 = fruits[i];
                    current = i - start + 1;
                }

                if (fruits[i] != fruits[i - 1])
                {
                    start = i;
                }
            }

            return Math.Max(response, current);
        }
    }
}