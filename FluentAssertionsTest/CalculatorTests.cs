using Xunit;
using FluentAssertions;

namespace FluentAssertionsTest
{
    public class CalculatorTests
    {
        public Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            var a = 5;
            var b = 3;

            var result = _calculator.Add(a, b);

            result.Should().Be(8);
        }

        [Fact]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            var a = 10;
            var b = 4;

            var result = _calculator.Subtract(a, b);

            result.Should().Be(6);
        }

        [Fact]
        public void Multiply_ShouldReturnCorrectProduct()
        {
            var a = 6;
            var b = 7;

            var result = _calculator.Multiply(a, b);

            result.Should().Be(42);
        }

        [Fact]
        public void Divide_ShouldReturnCorrectQuotient()
        {
            var a = 20;
            var b = 5;

            var result = _calculator.Divide(a, b);

            result.Should().Be(4);
        }

        [Fact]
        public void Divide_ShouldThrowDivideByZeroException()
        {
            var a = 10;
            var b = 0;

            Action act = () => _calculator.Divide(a, b);

            act.Should().Throw<DivideByZeroException>();
        }
    }

    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            return a / b;
        }
    }
}

