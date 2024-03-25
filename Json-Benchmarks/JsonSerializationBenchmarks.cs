using BenchmarkDotNet.Attributes;
using Bond;
using Bond.Protocols;
using System.Text;
using System.Text.Json;

namespace Json_Benchmarks;

[MemoryDiagnoser]
public class JsonSerializationBenchmarks
{
    private Person _person = new()
    {
        Name = "Random Person",
        Age = 30,
        Address = "Random Address",
        //Gender = Gender.Male,
        PhoneNumbers = ["123-456-7890", "123-456-7891", "123-456-7892"]
    };

    private BondPerson _bondPerson = new()
    {
        Name = "Random Person",
        Age = 30,
        Address = "Random Address",
        PhoneNumbers = ["123-456-7890", "123-456-7891", "123-456-7892"]
    };

    private StringBuilder jsonString = new();

    [Benchmark]
    public string SystemTextJson_Ser() => JsonSerializer.Serialize(_person);

    [Benchmark]
    public string SystemTextJson_SerSG() => JsonSerializer.Serialize(_person, PersonJsonContext.Default.Person);

    [Benchmark]
    public string Bond_Ser()
    {
        SimpleJsonWriter jsonWriter = new();
        Serialize.To(jsonWriter, _bondPerson);

        jsonWriter.Flush();
        return jsonString.ToString();
    }

}
