# Json Benchmarks

This repository contains a set of benchmarks for JSON libraries in .NET. The goal is to provide a fair comparison of the performance of these libraries.

## Libraries tested in benchmarks

- [System.Text.Json (Built-in)](https://docs.microsoft.com/en-us/dotnet/api/system.text.json)
- [Bond](https://microsoft.github.io/bond/manual/bond_cs.html)

## Running the benchmarks

The benchmarks are tested using [BenchmarkDotNet](https://benchmarkdotnet.org/)

## Latest Test Results

```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22621.3296/22H2/2022Update/SunValley2)
12th Gen Intel Core i7-1270P, 1 CPU, 16 logical and 12 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
```

| Method               | Mean            | Error           | StdDev          | Gen0      | Gen1     | Gen2     | Allocated  |
|--------------------- |----------------:|----------------:|----------------:|----------:|---------:|---------:|-----------:|
| SystemTextJson_Ser   |        436.1 ns |         8.67 ns |         8.51 ns |    0.0620 |        - |        - |      584 B |
| SystemTextJson_SerSG |        252.9 ns |         4.80 ns |         4.49 ns |    0.0286 |        - |        - |      272 B |
| Bond_Ser             | 10,083,449.5 ns | 1,031,608.75 ns | 2,959,878.88 ns | 1000.4883 | 999.5117 | 999.5117 | 58243023 B |
