using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SampleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("pokedex.json");
            var pokedex = JsonConvert.DeserializeObject<IEnumerable<Pokemon>>(json);

            var pagedPokedex = pokedex.ToPagedList(1, 20);

            while (true)
            {
                Console.WriteLine($"Page:{pagedPokedex.Page}");
                Console.WriteLine("-----------------------------");
                foreach (var pokemon in pagedPokedex)
                {
                    Console.WriteLine($"{pokemon.Id}\t{pokemon.Name.English}\t{string.Join(",", pokemon.Type)}");
                }
                Console.WriteLine("-----------------------------");

                if (pagedPokedex.HasNext)
                    pagedPokedex = pokedex.ToPagedList(pagedPokedex.Page + 1, 20);
                else
                    break;

                Console.ReadKey();
            } 
        }
    }
}
