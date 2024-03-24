using System.Text.Json.Serialization;

namespace Json_Benchmarks;

internal sealed class Person
{
    public string Name { get; set; } = default!;

    public int Age { get; set; }

    public string? Address { get; set; }

    //public Gender Gender { get; set; }

    public List<string>? PhoneNumbers { get; set; }
}

public enum Gender
{
    None,
    Male,
    Female,
    Other
}

[JsonSerializable(typeof(Person), GenerationMode = JsonSourceGenerationMode.Default)]
internal partial class PersonJsonContext : JsonSerializerContext;
