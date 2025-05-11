namespace Pokemon.Dashboard.Model;

public class Pokemon
{
    public string? name { get; set; }
    public int id { get; set; }
    public int height { get; set; }

    public int weight { get; set; }
    // public int hp { get; set; } // HP hinzufügen
     public PokemonSprites? sprites { get; set; }
     public List<PokemonAbility>? abilities { get; set; } // Fähigkeiten hinzufügen
     public List<PokemonType>? types { get; set; } // Typen hinzufügen

}

public class PokemonAbility
{
    public Ability? ability { get; set; }
}

public class Ability
{
    public string? name { get; set; }
}

public class PokemonType
{
    public Type? type { get; set; }
}

public class Type
{
    public string? name { get; set; }
}