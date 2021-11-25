using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace marvelApi
{
    public class HeroesRepository
    {
        HttpClient client = new HttpClient();

        public HeroesRepository()
        {
            client.BaseAddress = new Uri("http://gateway.marvel.com/v1/public");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<HeroesResponse>> GetHeroesAsync()
        {
            var ts = DateTime.Now.ToString();
            var apiKey = "964f63713d87a995b7e6f5318da827ea";
            var hash = "e48d3194289ff5c76da75ed9c36432b5";
            
            // Console.WriteLine("Qual herói você gostaria de buscar? \n");
            var heroeName = "Thor";

            HttpResponseMessage response = await client.GetAsync($"/characters?ts={ts}&apikey={apiKey}&hash={hash}&name={heroeName}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<HeroesResponse>>(data);
            }
            return new List<HeroesResponse>();
        }
    }
}