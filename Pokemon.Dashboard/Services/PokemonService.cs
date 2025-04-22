using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Pokemon.Dashboard.Services
{
    public class PokemonService
    {
        private readonly HttpClient _http;

        public PokemonService(HttpClient http)
        {
            _http = http;
        }

        public async Task<PokemonModel?> GetPokemonAsync(string name)
        {
            try
            {
                return await _http.GetFromJsonAsync<PokemonModel>($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");
            }
            catch
            {
                return null;
            }
        }
    }

    public class PokemonModel
    {
        public string name { get; set; } = string.Empty;
        public int height { get; set; }
        public int weight { get; set; }
        public List<TypeWrapper> types { get; set; } = new();
        public Sprites sprites { get; set; } = new();
        public List<StatWrapper> stats { get; set; } = new();
    }

    public class TypeWrapper
    {
        public TypeDetail type { get; set; } = new();
    }

    public class TypeDetail
    {
        public string name { get; set; } = string.Empty;
    }

    public class Sprites
    {
        public string front_default { get; set; } = string.Empty;
    }

    public class StatWrapper
    {
        public Stat stat { get; set; } = new();
        public int base_stat { get; set; }
    }

    public class Stat
    {
        public string name { get; set; } = string.Empty;
    }

}
