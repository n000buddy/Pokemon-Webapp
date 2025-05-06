namespace Pokemon.Dashboard.Model;

public class Pokemon
{
    public string? name { get; set; }
    public int id { get; set; }
    public int height { get; set; }
    public int weight { get; set; }
    public PokemonSprites? sprites { get; set; }
}