using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = { "YYNN", "YYYN", "NYYN", "NNNY" };
            int friendCircles = FriendCircles(input);
            Console.WriteLine(friendCircles);
            Console.ReadLine();
        }

        static int FriendCircles(string[] friends)
        {
            int length = friends.Length;
            if (friends == null || length < 1)
            {
                return 0;
            }
            bool[,] visited = new bool[length, length];
            for (int i = 0; i < visited.GetLength(0); i++)
            {
                for (int j = 0; j < visited.GetLength(1); j++)
                {
                    visited[i, j] = false;
                }
            }

            int circlesFound = 0;

            for (int i = 0; i < length; i++)
            {
                char[] row = friends[i].ToCharArray();
                for (int j = 0; j < row.Length; j++)
                {
                    if (!visited[i, j] && row[j] == 'Y')
                    {
                        circlesFound++;
                        visited[i, j] = true;
                        CrossOffCircles(friends, visited, j);
                    }
                }
            }

            return circlesFound;
        }




        static void CrossOffCircles(string[] friends, bool[,] visited, int index)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(index);
            while (queue.Count > 0)
            {
                int i = queue.Dequeue();
                char[] row = friends[i].ToCharArray();
                for (int j = 0; j < friends.Length; j++)
                {
                    if (!visited[i, j] && row[j] == 'Y')
                    {
                        visited[i, j] = true;
                        queue.Enqueue(j);
                    }
                }
            }
        }
    }
}
