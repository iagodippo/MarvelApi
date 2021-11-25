using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace marvelApi
{
    class MarvelApi
    {
        static async Task Main(string[] args)
        {
            try
            {
                var client = RestService.For<IMarvelApiService>("http://gateway.marvel.com/v1/public");
                Console.WriteLine("Informe o nome do herói que deseja buscar: ");

                string userHeroe = Console.ReadLine().ToString();
                string timeStamp = DateTime.Now.ToString();
                string publicKey = "964f63713d87a995b7e6f5318da827ea";
                string privateKey = "cc6aadb724975b2b57960f93903ab017a7a7f2f5";
                string hashKey = GenerateHashMd5(timeStamp + privateKey + publicKey);

                Console.WriteLine($"Buscando informações do herói: {userHeroe}");

                var heroeReturn = await client.GetHeroeAsync(userHeroe, timeStamp, publicKey, hashKey);

                Console.WriteLine($"\nNome: {heroeReturn.Data.Results[0].Name}\nDescrição: {heroeReturn.Data.Results[0].Description}");
                Console.ReadKey();

            } catch(Exception e) 
            {
                Console.WriteLine($"Erro na consulta de herói! {e.Message}");
            }
        }

        public static string GenerateHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
