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
> :four: Using FuncInvoke
>

In order to run benchmarks, type these commands in your favorite terminal :
>
> :writing_hand: `.\App.exe --filter DynamicMethodBench`
>
> :writing_hand: `.\App.exe --anyCategories=MethodInfoInvoke`
>
> :writing_hand: `.\App.exe --anyCategories=DelegateDynamicInvoke`
>
> :writing_hand: `.\App.exe --anyCategories=DynamicCastInvoke`
>
> :writing_hand: `.\App.exe --anyCategories=FuncInvoke`
>

```
|                         Method |            Categories |         Mean |      Error |     StdDev |          Min |          Max | Rank |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------------- |---------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-----:|-------:|-------:|------:|----------:|
|        PrivateMethodInfoInvoke |      MethodInfoInvoke |    299.02 ns |   4.184 ns |   3.913 ns |    294.10 ns |    306.77 ns |    1 | 0.0558 |      - |     - |     176 B |
|      ProtectedMethodInfoInvoke |      MethodInfoInvoke |    300.55 ns |   3.261 ns |   3.050 ns |    296.21 ns |    306.66 ns |    1 | 0.0558 |      - |     - |     176 B |
|         PublicMethodInfoInvoke |      MethodInfoInvoke |    301.13 ns |   2.600 ns |   2.171 ns |    298.23 ns |    305.89 ns |    1 | 0.0558 |      - |     - |     176 B |
|                                |                       |              |            |            |              |              |      |        |        |       |           |
|   PrivateDelegateDynamicInvoke | DelegateDynamicInvoke |  1,514.44 ns |  17.985 ns |  16.824 ns |  1,483.31 ns |  1,547.06 ns |    1 | 0.0992 |      - |     - |     312 B |
|    PublicDelegateDynamicInvoke | DelegateDynamicInvoke |  1,516.57 ns |  20.886 ns |  24.053 ns |  1,489.97 ns |  1,595.51 ns |    1 | 0.0992 |      - |     - |     312 B |
| ProtectedDelegateDynamicInvoke | DelegateDynamicInvoke |  1,524.06 ns |  29.901 ns |  39.917 ns |  1,456.34 ns |  1,584.77 ns |    1 | 0.0992 |      - |     - |     312 B |
|                                |                       |              |            |            |              |              |      |        |        |       |           |
|        PublicDynamicCastInvoke |     DynamicCastInvoke |     23.73 ns |   0.103 ns |   0.081 ns |     23.57 ns |     23.85 ns |    1 | 0.0229 |      - |     - |      72 B |
|     ProtectedDynamicCastInvoke |     DynamicCastInvoke |     61.18 ns |   0.711 ns |   0.594 ns |     60.16 ns |     62.47 ns |    2 | 0.0510 |      - |     - |     160 B |
|       PrivateDynamicCastInvoke |     DynamicCastInvoke |     61.84 ns |   0.346 ns |   0.307 ns |     61.38 ns |     62.45 ns |    2 | 0.0509 |      - |     - |     160 B |
|                                |                       |              |            |            |              |              |      |        |        |       |           |
|              PrivateFuncInvoke |            FuncInvoke | 87,554.53 ns | 749.636 ns | 701.210 ns | 86,731.07 ns | 88,854.02 ns |    1 | 1.5869 | 0.8545 |     - |    5056 B |
|               PublicFuncInvoke |            FuncInvoke | 88,628.63 ns | 740.248 ns | 656.210 ns | 87,863.70 ns | 89,812.93 ns |    1 | 1.5869 | 0.8545 |     - |    5056 B |
|            ProtectedFuncInvoke |            FuncInvoke | 88,786.06 ns | 857.615 ns | 802.214 ns | 87,422.49 ns | 90,000.67 ns |    1 | 1.5869 | 0.8545 |     - |    5056 B |
```

**`Tools`** : vs19, net 5.0