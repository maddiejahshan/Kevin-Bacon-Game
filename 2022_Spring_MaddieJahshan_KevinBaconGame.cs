using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KevinBaconGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.Load the movie database from the IMDB file into a graph object
            string filename = "imdb.txt";
            File.ReadAllText(filename);

            string line = "Aadil | Ghandi(1982)";

            string[] tokens = line.Split("|");
            string actor1 = tokens[0];
            string movie = tokens[1];

            actor1.Substring(0, count++); 

            filename.AddVertex(actor1); //?

            // 2. Read console input such as "Antonio Banderas and Audrey Hepburn"
            Console.WriteLine("Enter actor/actress name.");
            string input = Console.ReadLine();
            input = actor1;
            
            
            // 3.Verify that each actress / actor is valid
            void AddVertex(T vertex)
            {
                if (input != filename) // filename - something in the database?
                {
                    Console.WriteLine($"Error: {input} is invalid.");
                }
                else
                {
                    filename.AddVertex(actor1);
                }

            }


            // 4.Verify that the two people are connected
            g.TestConnectedTo(actor1, actor2);
            g.TestConnectedTo(actor1, actor2);

            // 5.Find the shortest path from one actor/ actress to the other
            g.FindShortestPath(actor1, actor2);
            /*  
                6.Calculate the degrees of separation score
                7.Display the path from one person to the other
                8.Loop back to step #2 until the user types "quit" or "exit
             */
        }
    }
}
