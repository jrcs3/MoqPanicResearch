using NSubstitute;
using NUnit.Framework;

namespace AppToTest.NSubstitute
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Call_GiveItBackToMe()
        {
            string someString = "SomeString";
            var SomethingToTestMock = Substitute.For<ISomethingToTest>();
            SomethingToTestMock.GiveItBackToMe(someString).Returns(someString);

            Assert.That(SomethingToTestMock.GiveItBackToMe(someString), Is.EqualTo(someString));
        }

        [Test]
        public void Call_SomeNumberICareAbout()
        {
            int someNumberICareAbout = 42;
            int anotherNumberICareAbout = 7;

            // Backing value for the SomeNumberICareAbout property
            int actualSomeNumberICareAbout = 0;


            var SomethingToTestMock = Substitute.For<ISomethingToTest>();

            // NSubstitute handles properties semi-automatically with the .Do callback
            SomethingToTestMock.WhenForAnyArgs(x => x.SomeNumberICareAbout = 0)
                .Do(callInfo => actualSomeNumberICareAbout = callInfo.Arg<int>());

            SomethingToTestMock.SomeNumberICareAbout = someNumberICareAbout;
            Assert.That(SomethingToTestMock.SomeNumberICareAbout, Is.EqualTo(someNumberICareAbout));
            // NSubstitute specific test
            Assert.That(actualSomeNumberICareAbout, Is.EqualTo(someNumberICareAbout));

            SomethingToTestMock.SomeNumberICareAbout = anotherNumberICareAbout;
            Assert.That(SomethingToTestMock.SomeNumberICareAbout, Is.EqualTo(anotherNumberICareAbout));
            // NSubstitute specific test
            Assert.That(actualSomeNumberICareAbout, Is.EqualTo(anotherNumberICareAbout));
        }

        [Test]
        public void Check_CallsCount()
        {
            string someString = "SomeString";
            var SomethingToTestMock = Substitute.For<ISomethingToTest>();

            SomethingToTestMock.SomethingToBeCalled(someString);

            SomethingToTestMock.Received().SomethingToBeCalled(someString);
            SomethingToTestMock.DidNotReceiveWithAnyArgs().SomethingToBeIgnored(Arg.Any<string>());
        }

        [Test]
        public void Call_BooleanMethods()
        {
            var SomethingToTestMock = Substitute.For<ISomethingToTest>();
            SomethingToTestMock.ReturnTrue().Returns(true);
            SomethingToTestMock.ReturnFalse().Returns(false);

            Assert.That(SomethingToTestMock.ReturnTrue(), Is.True);
            Assert.That(SomethingToTestMock.ReturnFalse(), Is.False);
        }

        [Test]
        public void Call_GiveItBackToMeAltered()
        {
            // Todo
        }
    }
}