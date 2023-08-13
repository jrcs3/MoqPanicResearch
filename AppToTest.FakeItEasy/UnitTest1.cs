using FakeItEasy;

namespace AppToTest.FakeItEasy
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

            var SomethingToTestMock = A.Fake<ISomethingToTest>();
            A.CallTo(() => SomethingToTestMock.GiveItBackToMe(someString)).Returns(someString);
            A.CallTo(() => SomethingToTestMock.ReturnTrue()).Returns(true);
            A.CallTo(() => SomethingToTestMock.ReturnFalse()).Returns(false);

            SomethingToTestMock.SomeNumberICareAbout = someNumberICareAbout;
            SomethingToTestMock.SomethingToBeCalled(someString);

            Assert.That(SomethingToTestMock.GiveItBackToMe(someString), Is.EqualTo(someString));
            Assert.That(SomethingToTestMock.ReturnTrue(), Is.True);
            Assert.That(SomethingToTestMock.ReturnFalse(), Is.False);
            Assert.That(SomethingToTestMock.SomeNumberICareAbout, Is.EqualTo(someNumberICareAbout));
            A.CallTo(() => SomethingToTestMock.SomethingToBeCalled(someString)).MustHaveHappened();
            A.CallTo(() => SomethingToTestMock.SomethingToBeIgnored(someString)).MustNotHaveHappened();
        }
    }
}