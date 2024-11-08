using FluentAssertions;

namespace FluentAssertionsTest
{
    public class FluentAssertionsTutorial
    {
        [Fact]
        public void Tutorial()
        {
            string actual = "ABCDEFGHI";
            var result = actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);
        }

        [Fact]
        public void Tutorial2()
        {
            IEnumerable<int> numbers = new[] { 1, 2, 3 };

            numbers.Should().OnlyContain(n => n > 0);
            numbers.Should().HaveCount(4, "because we thought we put four items in the collection");
        }

        [Fact]
        public void Tutorial3()
        {
            string username = "dennis";
            username.Should().Be("jonas");
        }

        [Fact]
        public void Tutorial4()
        {
            object theObject = null;

            theObject.Should().BeNull("because the value is null");
            theObject.Should().NotBeNull();

            theObject = "whatever";
            theObject.Should().BeOfType<string>("because a {0} is set", typeof(string));
            theObject.Should().BeOfType(typeof(string), "because a {0} is set", typeof(string));
        }
            
    }
}
