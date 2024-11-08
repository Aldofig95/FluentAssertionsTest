using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;

namespace FluentAssertionsTest
{

    public class CustomAssertionTests
    {
        [Fact]
        public void FullNameAssertion()
        {
            var person = new Person { FullName = "John Doe" };
            person.Should().HaveFullName("John Doe");
        }
    }


    public class PersonAssertions : ReferenceTypeAssertions<Person, PersonAssertions>
    {
        public PersonAssertions(Person instance) : base(instance) { }

        protected override string Identifier => "person";

        public AndConstraint<PersonAssertions> HaveFullName(string expectedFullName, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.FullName == expectedFullName)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:person} to have full name {0}{reason}, but found {1}.", expectedFullName, Subject.FullName);

            return new AndConstraint<PersonAssertions>(this);
        }
    }

    public static class PersonAssertionsExtensions
    {
        public static PersonAssertions Should(this Person instance)
        {
            return new PersonAssertions(instance);
        }
    }

    public class Person
    {
        public string FullName { get; set; }
    }
}
