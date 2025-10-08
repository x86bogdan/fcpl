using System.Net.Http;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// Utility class to retrieve data from the web
    /// </summary>
    /// <example>
    /// deserialization 
    /// string jsonData = await GetPokemonDataAsync("ditto");
    /// Pokemon myPokemon = JsonSerializer.Deserialize<Pokemon>(jsonData);
    /// </example>
    public static class PokemonUtils
    {
        // retrieve the Pokemon data
        public static async Task<string> GetPokemonDataAsync(string pokemonName)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/{pokemonName.ToLower()}";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return null; // Or throw an exception
            }
        }
    }
}
