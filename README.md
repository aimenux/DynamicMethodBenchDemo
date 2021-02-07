![.NET](https://github.com/aimenux/DynamicMethodBenchDemo/workflows/.NET/badge.svg)

# DynamicMethodBenchDemo
```
Benchmarking ways of dynamically invoking methods
```

In this demo, i m using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) library in order to benchmark various ways of dynamically invoking (public, protected, private) methods :
>
> :one: Using MethodInfoInvoke
>
> :two: Using DelegateDynamicInvoke
>
> :three: Using DynamicCastInvoke
>

In order to run benchmarks, type these commands in your favorite terminal :
>
> :writing_hand: `.\App.exe --filter DynamicMethodBench`
>

```
|                         Method |            Categories |        Mean |     Error |    StdDev |         Min |         Max | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |---------------------- |------------:|----------:|----------:|------------:|------------:|-----:|-------:|------:|------:|----------:|
|         PublicMethodInfoInvoke |      MethodInfoInvoke |   298.88 ns |  2.969 ns |  2.318 ns |   295.75 ns |   303.18 ns |    1 | 0.0558 |     - |     - |     176 B |
|      ProtectedMethodInfoInvoke |      MethodInfoInvoke |   309.86 ns |  5.746 ns |  5.374 ns |   299.18 ns |   318.42 ns |    2 | 0.0558 |     - |     - |     176 B |
|        PrivateMethodInfoInvoke |      MethodInfoInvoke |   311.75 ns |  6.168 ns |  7.343 ns |   302.10 ns |   325.60 ns |    2 | 0.0558 |     - |     - |     176 B |
|                                |                       |             |           |           |             |             |      |        |       |       |           |
|   PrivateDelegateDynamicInvoke | DelegateDynamicInvoke | 1,465.89 ns | 14.011 ns | 13.106 ns | 1,448.71 ns | 1,486.21 ns |    1 | 0.0992 |     - |     - |     312 B |
|    PublicDelegateDynamicInvoke | DelegateDynamicInvoke | 1,515.11 ns | 24.103 ns | 25.790 ns | 1,487.89 ns | 1,602.30 ns |    2 | 0.0992 |     - |     - |     312 B |
| ProtectedDelegateDynamicInvoke | DelegateDynamicInvoke | 1,535.90 ns | 29.424 ns | 43.129 ns | 1,487.79 ns | 1,650.24 ns |    2 | 0.0992 |     - |     - |     312 B |
|                                |                       |             |           |           |             |             |      |        |       |       |           |
|        PublicDynamicCastInvoke |     DynamicCastInvoke |    23.84 ns |  0.290 ns |  0.271 ns |    23.51 ns |    24.47 ns |    1 | 0.0229 |     - |     - |      72 B |
|     ProtectedDynamicCastInvoke |     DynamicCastInvoke |    58.48 ns |  0.328 ns |  0.291 ns |    58.21 ns |    59.26 ns |    2 | 0.0510 |     - |     - |     160 B |
|       PrivateDynamicCastInvoke |     DynamicCastInvoke |    66.15 ns |  0.351 ns |  0.311 ns |    65.33 ns |    66.61 ns |    3 | 0.0509 |     - |     - |     160 B |
```

**`Tools`** : vs19, net 5.0