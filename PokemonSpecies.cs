using System.Text.Json;
using System.Text.Json.Serialization;

// This is the simple class to deserialize the species data into.
// It *only* looks for the properties we care about and ignores the rest.
public class PokemonSpecies
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("is_legendary")]
    public bool IsLegendary { get; set; }

    [JsonPropertyName("is_mythical")]
    public bool IsMythical { get; set; }
}

/* usage
var speciesUrl = "https://pokeapi.co/api/v2/pokemon-species/1/"; // Bulbasaur
var speciesData = PokemonSpeciesHelper.GetSpeciesDataAsync(speciesUrl).Result;
*/
public static class PokemonSpeciesHelper
{
    // Use a single, static HttpClient for efficiency.
    private static readonly HttpClient client = new HttpClient();

    /// <summary>
    /// Fetches and deserializes Pokemon species data from a given URL.
    /// </summary>
    /// <param name="speciesUrl">The URL to the pokemon-species API endpoint.</param>
    /// <returns>A PokemonSpecies object or null if it fails.</returns>
    public static async Task<PokemonSpecies> GetSpeciesDataAsync(string speciesUrl)
    {
        if (string.IsNullOrEmpty(speciesUrl))
            return null;

        try
        {
            // Send the GET request
            HttpResponseMessage response = await client.GetAsync(speciesUrl);

            if (response.IsSuccessStatusCode)
            {
                // Read the JSON content
                string jsonString = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON into our simple PokemonSpecies class
                return JsonSerializer.Deserialize<PokemonSpecies>(jsonString);
            }
            else
            {
                Console.WriteLine($"Error fetching species data: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception fetching species data: {ex.Message}");
            return null;
        }
    }
}
