using System;
using System.IO;
using MathGraph;
using System.Collections.Generic;

namespace KevinBaconGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // --HW10C-- //
            StreamReader imdb = new StreamReader(args[0]);
            MathGraph<string> graph = new MathGraph<string>();


            string filename = args[0];
            string actor1 = args[1];
            string actor2 = args[2];

            if (args.Length == 0)
            {
                Console.WriteLine("Error: You did not enter a filename");
                return;
            }
            else if (args.Length == 3)
            {

                if (File.Exists(filename))
                {
                    Console.WriteLine($"Your file {filename} exists");
                }
                else
                {
                    Console.WriteLine($"Your file {filename} does not exist");
                    return;
                }

            }
            else if (args.Length == 1)
            {
                Console.WriteLine($"The actor was not included.");
            }
            // 1.Load the movie database from the IMDB file into a graph object

            while (!imdb.EndOfStream)
            {
                string line = imdb.ReadLine();

                string[] tokens = line.Split('|');
                string name = tokens[0];
                string movie = tokens[1];

                if (name.Contains("("))
                {
                    string[] names = line.Split('(');
                    string justname = names[0];
                    justname = justname.Trim();

                    if (!graph.ContainsVertex(justname))
                    {
                        graph.AddVertex(justname);
                    }

                    if (!graph.ContainsVertex(movie))
                    {
                        graph.AddVertex(movie);
                    }

                    if (!graph.ContainsEdge(justname, movie))
                    {
                        graph.AddEdge(justname, movie);
                    }
                }

                if (!graph.ContainsVertex(name))//if movie does not ALREADY exist THEN print movie name
                {
                    graph.AddVertex(name);
                }

                if (!graph.ContainsVertex(movie))
                {
                    graph.AddVertex(movie);
                }

                if (!graph.ContainsEdge(name, movie))
                {
                    graph.AddEdge(name, movie);
                }

            }
            Console.WriteLine($"Complete reading file{graph.CountVertices()}");


            // 2. Read console input such as "Antonio Banderas and Audrey Hepburn"
            PlayGame(graph, actor1, actor2);
            
            while (true)
            {
                //Console.Write("Please enter two actors:");
                string UserInput = Console.ReadLine();
                UserInput = UserInput.ToUpper();

                if (UserInput == "EXIT")
                {
                    break;
                }

                // 3.Verify that each actress / actor is valid
            }

            //PlayGame(graph, actor1, actor2);
        }

        public static void PlayGame(MathGraph<string> g, string actor1, string actor2)
        {

            // 4.Verify that the two people are connected
            if (!g.TestConnectedTo(actor1, actor2))
            {
                Console.WriteLine("The actors cannot be connected.");
            }
            else 
            {
                List<string> results = g.FindShortestPath(actor1, actor2);
                string[] arr = new string[results.Count];

                for (int j = 0; j < arr.Length - 2; j += 2)
                {
                    Console.WriteLine($"{results[j]} was in {results[j + 1]} with {results[j + 2]}.");
                    Console.WriteLine($"Fun Fact: {actor1} has been in {g.CountAdjacent(results[j])} movie(s).");
                    Console.WriteLine($"Fun Fact: {actor2} has been in {g.CountVertices() / 2} movie(s).");
                }
                Console.WriteLine($"The shortest path is {(results.Count - 1 / 2)} degrees of separation.");
            }
            Console.WriteLine("> ");
            string input = Console.ReadLine();
            Console.WriteLine();

            if(input.ToLower() == "quit" || input.ToLower() == "exit")
            {
                return;
            }
        } 
    }
}

