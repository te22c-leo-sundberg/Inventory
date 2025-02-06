using System.Text.Json.Serialization;

public class Item : Inventory
{
    [JsonInclude] public string Name;
    [JsonInclude] public float Weight;
}