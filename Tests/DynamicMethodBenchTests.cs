using App;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class DynamicMethodBenchTests
    {
        [Theory]
        [InlineData(BenchSample.PublicSumMethod, 1, 4, 5)]
        [InlineData(BenchSample.ProtectedSumMethod, 1, 4, 5)]
        [InlineData(BenchSample.PrivateSumMethod, 1, 4, 5)]
        public void Should_MethodInfoInvoke_Be_Valid(string name, int left, int right, int expected)
        {
            // arrange
            // act
            var result = DynamicMethodBench.MethodInfoInvoke(name, left, right);

            // assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(BenchSample.PublicSumMethod, 1, 4, 5)]
        [InlineData(BenchSample.ProtectedSumMethod, 1, 4, 5)]
        [InlineData(BenchSample.PrivateSumMethod, 1, 4, 5)]
        public void Should_DelegateDynamicInvoke_Be_Valid(string name, int left, int right, int expected)
        {
            // arrange
            // act
            var result = DynamicMethodBench.DelegateDynamicInvoke(name, left, right);

            // assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 4, 5)]
        [InlineData(4, 1, 5)]
        public void Should_Public_DynamicCastInvoke_Be_Valid(int left, int right, int expected)
        {
            // arrange
            var bench = new DynamicMethodBench(left, right);
            // act
            var result = bench.PublicDynamicCastInvoke();

            // assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 4, 5)]
        [InlineData(4, 1, 5)]
        public void Should_Protected_DynamicCastInvoke_Be_Valid(int left, int right, int expected)
        {
            // arrange
            var bench = new DynamicMethodBench(left, right);
            // act
            var result = bench.ProtectedDynamicCastInvoke();

            // assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 4, 5)]
        [InlineData(4, 1, 5)]
        public void Should_Private_DynamicCastInvoke_Be_Valid(int left, int right, int expected)
        {
            // arrange
            var bench = new DynamicMethodBench(left, right);
            // act
            var result = bench.PrivateDynamicCastInvoke();

            // assert
            result.Should().Be(expected);
        }
    }
}
