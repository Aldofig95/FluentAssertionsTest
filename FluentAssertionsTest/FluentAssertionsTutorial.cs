using FluentAssertions;

namespace FluentAssertionsTest
{
    public class FluentAssertionsTutorial
    {
        [Fact]
        //Normal Success tutorial
        public void Tutorial()
        {
            string actual = "ABCDEFGHI";
            var result = actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);
        }

        [Fact]
        //Normal Fail tutorial
        public void Tutorial2()
        {
            IEnumerable<int> numbers = new[] { 1, 2, 3 };

            numbers.Should().OnlyContain(n => n > 0);
            numbers.Should().HaveCount(4, "because we thought we put four items in the collection");
        }

        [Fact]
        //Fail with trace explanation
        public void Tutorial3()
        {
            string username = "dennis";
            username.Should().Be("jonas");
        }

        [Fact]
        //Uses of nullables and BeOfType
        public void Tutorial4()
        {
            object theObject = null;

            theObject.Should().BeNull("because the value is null");
            theObject.Should().NotBeNull();

            theObject = "whatever";
            theObject.Should().BeOfType<string>("because a {0} is set", typeof(string));
            theObject.Should().BeOfType(typeof(string), "because a {0} is set", typeof(string));
        }
        [Fact]
        //Numeric Type
        public void Tutorial5()
        {
            float value = 3.1415F;
            value.Should().BeApproximately(3.14F, 0.01F);
        }
            
    }
}
