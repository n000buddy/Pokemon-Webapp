using System.Collections.Concurrent;
using System.Text.Json;
using Pokemon.Dashboard.Model;

namespace Pokemon.Dashboard.Services;

public class PokemonService
{
    private readonly HttpClient _httpClient;
    private static readonly ConcurrentDictionary<string, Model.Pokemon?> Cache = new();

    public PokemonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Model.Pokemon?> GetPokemonAsync(string name)
    {
        if (Cache.TryGetValue(name, out var cachedPokemon))
        {
            return cachedPokemon;
        }
        try
        {
            var options = new JsonSerializerOptions
            {
                MaxDepth = 64
            };

            var response = await _httpClient.GetAsync($"pokemon/{name}");
            response.EnsureSuccessStatusCode();

            var pokemon = await response.Content.ReadFromJsonAsync<Model.Pokemon>(options);
            if (pokemon != null)
            {
                Cache[name] = pokemon;
            }

            return pokemon;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error when retrieving the Pokemon list: {ex.Message}");
            return null;
        }
    }
    public async Task<NamedApiResourceList?> GetPokemonListAsync(int limit = 200)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                MaxDepth = 64
            };

            var response = await _httpClient.GetAsync($"pokemon?limit={limit}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<NamedApiResourceList>(options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error when retrieving the Pokemon list: {ex.Message}");
            return null;
        }
    } 
    public async Task<List<Model.Pokemon?>> GetPokemonListAsync(IEnumerable<string> names)
    {
        var tasks = names.Select(GetPokemonAsync);
        return (await Task.WhenAll(tasks)).ToList();
    }
}

