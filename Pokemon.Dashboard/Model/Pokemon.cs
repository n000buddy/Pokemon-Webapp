namespace Pokemon.Dashboard.Model;

public class Pokemon
{
    public string? name { get; set; }
    public int id { get; set; }
    public int height { get; set; }
    
    public int base_experience { get; set; }
    public bool is_default { get; set; }
    public int weight  { get; set; }
    public int order {get; set;}
    
    public PokemonSprites? sprites { get; set; }
    
    
}