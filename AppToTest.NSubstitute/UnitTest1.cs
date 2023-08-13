using NSubstitute;

namespace AppToTest.NSubstitute
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string someString = "SomeString";
            int someNumberICareAbout = 42;
            int actualSomeNumberICareAbout = 0;

            var SomethingToTestMock = Substitute.For<ISomethingToTest>();
            SomethingToTestMock.GiveItBackToMe(someString).Returns(someString);
            SomethingToTestMock.ReturnTrue().Returns(true);
            SomethingToTestMock.ReturnFalse().Returns(false);
            SomethingToTestMock.WhenForAnyArgs(x => x.SomeNumberICareAbout = 0)
                .Do(callInfo => actualSomeNumberICareAbout = callInfo.Arg<int>());


            SomethingToTestMock.SomeNumberICareAbout = someNumberICareAbout;
            SomethingToTestMock.SomethingToBeCalled(someString);

            Assert.That(SomethingToTestMock.GiveItBackToMe(someString), Is.EqualTo(someString));
            Assert.That(SomethingToTestMock.ReturnTrue(), Is.True);
            Assert.That(SomethingToTestMock.ReturnFalse(), Is.False);
            Assert.That(SomethingToTestMock.SomeNumberICareAbout, Is.EqualTo(someNumberICareAbout));
            SomethingToTestMock.Received().SomethingToBeCalled(someString);
            SomethingToTestMock.DidNotReceiveWithAnyArgs().SomethingToBeIgnored(Arg.Any<string>());

            Assert.That(actualSomeNumberICareAbout, Is.EqualTo(someNumberICareAbout));
        }
    }
}