using Xunit;

namespace StringCalculator.Tests
{
    public class MultiplicationAdderTests
    {
        private readonly MultiplicationAdder _multiplicationAdder = new MultiplicationAdder();

        [Fact]
        public void Test_AddMultiplicationSign()
        {
            var result = _multiplicationAdder.AddMultiplicationSign("2(3+5)");
            Assert.Equal("2*(3+5)", result);
        }
    }
}
