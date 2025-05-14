namespace Pokemon.Dashboard.Model;

public class NamedApiResourceList
{
    public int count { get; set; }
    public string? next { get; set; }
    public string? previous { get; set; }
    public List<NamedApiResource>? results { get; set; }
}