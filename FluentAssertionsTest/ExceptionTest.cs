using Xunit;
using FluentAssertions;
using System;

namespace FluentAssertionsTest
{
    public class ExceptionTests
    {
        [Fact]
        //Testing when expecting an Exception
        public void ExceptionMethodTest()
        {
            //Will throw exception
            var testClass = new TestClass();
            Action act = () => testClass.ExceptionMethod();

            //act.Should().Throw<CustomException>()
            //    .WithMessage("An error happened.")
            //    .And.ErrorCode.Should().Be(42);
            act.Should().Throw<CustomException>()
                .WithMessage("An error happened.")
                .And.ErrorCode.Should().Be(43);
        }
    }

    public class TestClass
    {
        public void ExceptionMethod()
        {
            throw new CustomException("An error happened.", 42);
        }
    }

    public class CustomException : Exception
    {
        public int ErrorCode { get; }

        public CustomException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
