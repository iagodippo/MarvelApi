using System.Threading.Tasks;
using System;

namespace marvelApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new HeroesRepository();
            var heroes = repository.GetHeroesAsync();

            heroes.ContinueWith(task =>
            {
                var heroe = task.Result;
                foreach(var h in heroe)
                    Console.WriteLine(h.ToString());

                Environment.Exit(0);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );
            
            Console.ReadLine();
        }
    }
}
