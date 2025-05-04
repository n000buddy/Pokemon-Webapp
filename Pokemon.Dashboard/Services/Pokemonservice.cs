namespace Pokemon.Dashboard.Services;

public class PokemonService(HttpClient httpClient)
{
    public async Task<Pokemon.Dashboard.Model.Pokemon?> GetPokemonAsync(string name)
    {
        return await httpClient.GetFromJsonAsync<Pokemon.Dashboard.Model.Pokemon>($"pokemon/{name}");
    }
    
    public async Task<Model.NamedApiResourceList?> GetPokemonListAsync()
    {
        return await httpClient.GetFromJsonAsync<Model.NamedApiResourceList>("pokemon?limit=100");
    }
    
}