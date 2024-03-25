using BenchmarkDotNet.Attributes;
using Bond.Protocols;
using Bond;
using System.Text.Json;
using Bond.IO.Safe;

namespace Json_Benchmarks;

[MemoryDiagnoser]
public class BinarySerializationBenchmarks
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

    private OutputBuffer output = new();

    [Benchmark]
    public byte[] SystemTextJson_Ser() => JsonSerializer.SerializeToUtf8Bytes(_person);

    [Benchmark]
    public byte[] SystemTextJson_SerSG() => JsonSerializer.SerializeToUtf8Bytes(_person, PersonJsonContext.Default.Person);

    [Benchmark]
    public byte[] Bond_Ser()
    {
        OutputBuffer output = new();
        CompactBinaryWriter<OutputBuffer> writer = new(output);
        Serialize.To(writer, _bondPerson);
        return output.Data.Array;
    }
}
