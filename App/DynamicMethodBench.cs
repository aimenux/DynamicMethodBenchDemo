using System;
using System.Linq.Expressions;
using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace App
{
    [Config(typeof(BenchConfig))]
    public class DynamicMethodBench
    {
        private int _left, _right;

        private const BindingFlags Bindings = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        public DynamicMethodBench(int left = 0, int right = 0)
        {
            _left = left;
            _right = right;
        }

        [GlobalSetup]
        public void Setup()
        {
            const int max = 1_000_000;
            var random = new Random(Guid.NewGuid().GetHashCode());
            _left = random.Next(max);
            _right = random.Next(max);
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.MethodInfoInvoke))]
        public int PublicMethodInfoInvoke() => MethodInfoInvoke(BenchSample.PublicSumMethod, _left, _right);

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.MethodInfoInvoke))]
        public int ProtectedMethodInfoInvoke() => MethodInfoInvoke(BenchSample.ProtectedSumMethod, _left, _right);

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.MethodInfoInvoke))]
        public int PrivateMethodInfoInvoke() => MethodInfoInvoke(BenchSample.PrivateSumMethod, _left, _right);

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.DelegateDynamicInvoke))]
        public int PublicDelegateDynamicInvoke() => DelegateDynamicInvoke(BenchSample.PublicSumMethod, _left, _right);

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.DelegateDynamicInvoke))]
        public int ProtectedDelegateDynamicInvoke() => DelegateDynamicInvoke(BenchSample.ProtectedSumMethod, _left, _right);

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.DelegateDynamicInvoke))]
        public int PrivateDelegateDynamicInvoke() => DelegateDynamicInvoke(BenchSample.PrivateSumMethod, _left, _right);

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.DynamicCastInvoke))]
        public int PublicDynamicCastInvoke()
        {
            var sample = new BenchSample();
            var dynamicSample = (dynamic) sample;
            var result = dynamicSample.PublicSum(_left, _right);
            return Convert.ToInt32(result);
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.DynamicCastInvoke))]
        public int ProtectedDynamicCastInvoke()
        {
            var sample = new BenchSample();
            var dynamicSample = (dynamic) sample;
            var result = dynamicSample.ProtectedSum(_left, _right);
            return Convert.ToInt32(result);
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.DynamicCastInvoke))]
        public int PrivateDynamicCastInvoke()
        {
            var sample = new BenchSample();
            var dynamicSample = (dynamic) sample;
            var result = dynamicSample.PrivateSum(_left, _right);
            return Convert.ToInt32(result);
        }

        public static int MethodInfoInvoke(string methodName, int left, int right)
        {
            var sample = new BenchSample();
            var classType = typeof(BenchSample);
            var methodInfo = classType.GetMethod(methodName, Bindings);
            if (methodInfo == null) throw BenchException.UnfoundedMethod(methodName, classType);
            var result = methodInfo.Invoke(sample, new object[] {left, right});
            return Convert.ToInt32(result);
        }

        public static int DelegateDynamicInvoke(string methodName, int left, int right)
        {
            var sample = new BenchSample();
            var classType = typeof(BenchSample);
            var methodInfo = classType.GetMethod(methodName, Bindings);
            if (methodInfo == null) throw BenchException.UnfoundedMethod(methodName, classType);
            var delegateType = Expression.GetDelegateType(classType, typeof(int), typeof(int), typeof(int));
            var @delegate = Delegate.CreateDelegate(delegateType, methodInfo);
            var result = @delegate.DynamicInvoke(sample, left, right);
            return Convert.ToInt32(result);
        }
    }
}