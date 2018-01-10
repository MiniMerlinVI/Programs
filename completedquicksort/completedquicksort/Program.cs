using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace completedquicksort
{
    class Program
    {
        static void Quicksort(int[] Scores, int Low, int High)
        {
            if (Low < High)
            {
                int PivotLocation = Partition(Scores, Low, High);
                Quicksort(Scores, Low, PivotLocation);
                Quicksort(Scores, PivotLocation + 1, High);
            }



        }
        static int Partition(int[] Scores, int Low, int High)
        {
            int Pivot = Scores[Low];
            int leftwall = Low;

            for (int i = Low; i < High; i++)
            {

                if (Scores[i] < Pivot)
                {
                    int Hold = Scores[i];
                    Scores[i] = Scores[leftwall];
                    Scores[leftwall] = Hold;
                    leftwall++;
                }
            }

            int Hold2 = Pivot;
            Pivot = Scores[leftwall];
            Scores[leftwall] = Hold2;

            return leftwall;

        }



        static void Main(string[] args)
        {

            int[] Numbers = new int[25];
            Random rnd = new Random();
            Console.WriteLine("Before");
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = rnd.Next(1,25);
                Console.Write(Numbers[i] + " ");
            }

            Quicksort(Numbers, 0, Numbers.Length);

            Console.WriteLine();
            Console.WriteLine("After");
            for (int i = 0; i < Numbers.Length; i++)
            {
                Console.Write(Numbers[i] + " ");
            }
            Console.ReadLine();

        }
    }
}
