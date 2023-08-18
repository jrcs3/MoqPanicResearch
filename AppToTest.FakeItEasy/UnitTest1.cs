using FakeItEasy;
using NUnit.Framework;

namespace AppToTest.FakeItEasy
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
            var SomethingToTestMock = A.Fake<ISomethingToTest>();
            A.CallTo(() => SomethingToTestMock.GiveItBackToMe(someString)).Returns(someString);

            Assert.That(SomethingToTestMock.GiveItBackToMe(someString), Is.EqualTo(someString));
        }

        [Test]
        public void Call_SomeNumberICareAbout()
        {
            int someNumberICareAbout = 42;
            int anotherNumberICareAbout = 7;

            var SomethingToTestMock = A.Fake<ISomethingToTest>();

            SomethingToTestMock.SomeNumberICareAbout = someNumberICareAbout;
            Assert.That(SomethingToTestMock.SomeNumberICareAbout, Is.EqualTo(someNumberICareAbout));

            SomethingToTestMock.SomeNumberICareAbout = anotherNumberICareAbout;
            Assert.That(SomethingToTestMock.SomeNumberICareAbout, Is.EqualTo(anotherNumberICareAbout));
        }


        [Test]
        public void Check_CallsCount()
        {
            string someString = "SomeString";
            var SomethingToTestMock = A.Fake<ISomethingToTest>();

            SomethingToTestMock.SomethingToBeCalled(someString);

            A.CallTo(() => SomethingToTestMock.SomethingToBeCalled(someString)).MustHaveHappened();
            A.CallTo(() => SomethingToTestMock.SomethingToBeIgnored(someString)).MustNotHaveHappened();
        }


        [Test]
        public void Call_BooleanMethods()
        {
            var SomethingToTestMock = A.Fake<ISomethingToTest>();
            A.CallTo(() => SomethingToTestMock.ReturnTrue()).Returns(true);
            A.CallTo(() => SomethingToTestMock.ReturnFalse()).Returns(false);

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