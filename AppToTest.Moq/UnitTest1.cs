using Moq;
using NUnit.Framework;

namespace AppToTest.Moq
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
            var SomethingToTestMock = new Mock<ISomethingToTest>();
            SomethingToTestMock.Setup(x => x.GiveItBackToMe(someString)).Returns(someString);

            Assert.That(SomethingToTestMock.Object.GiveItBackToMe(someString), Is.EqualTo(someString));
        }

        [Test]
        public void Call_SomeNumberICareAbout()
        {
            int someNumberICareAbout = 42;
            int anotherNumberICareAbout = 7;

            var SomethingToTestMock = new Mock<ISomethingToTest>();

            // I had to man handle the propety with MOQ
            SomethingToTestMock.SetupSet(x => x.SomeNumberICareAbout = someNumberICareAbout).Verifiable();
            SomethingToTestMock.SetupSet(x => x.SomeNumberICareAbout = anotherNumberICareAbout).Verifiable();
            SomethingToTestMock.SetupSequence(x => x.SomeNumberICareAbout)
                .Returns(someNumberICareAbout)
                .Returns(anotherNumberICareAbout);

            SomethingToTestMock.Object.SomeNumberICareAbout = someNumberICareAbout;
            Assert.That(SomethingToTestMock.Object.SomeNumberICareAbout, Is.EqualTo(someNumberICareAbout));

            SomethingToTestMock.Object.SomeNumberICareAbout = anotherNumberICareAbout;
            Assert.That(SomethingToTestMock.Object.SomeNumberICareAbout, Is.EqualTo(anotherNumberICareAbout));
        }

        [Test]
        public void Check_CallsCount()
        {
            string someString = "SomeString";
            var SomethingToTestMock = new Mock<ISomethingToTest>();

            SomethingToTestMock.Object.SomethingToBeCalled(someString);

            SomethingToTestMock.Verify(x => x.SomethingToBeCalled(someString), Times.Once);
            SomethingToTestMock.Verify(x => x.SomethingToBeIgnored(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Call_BooleanMethods()
        {
            var SomethingToTestMock = new Mock<ISomethingToTest>();
            SomethingToTestMock.Setup(x => x.ReturnTrue()).Returns(true);
            SomethingToTestMock.Setup(x => x.ReturnFalse()).Returns(false);

            Assert.That(SomethingToTestMock.Object.ReturnTrue(), Is.True);
            Assert.That(SomethingToTestMock.Object.ReturnFalse(), Is.False);
        }

        [Test]
        public void Call_GiveItBackToMeAltered()
        {
            string someString = "SomeString";
            string alterPrefix = "Altered";
            var SomethingToTestMock = new Mock<ISomethingToTest>();

            SomethingToTestMock.Setup(x => x.GiveItBackToMeAltered(It.IsAny<string>()))
                .Returns((string it) =>
                {
                    return $"{alterPrefix} {it}";
                });

            Assert.That(SomethingToTestMock.Object.GiveItBackToMeAltered(someString), Is.EqualTo($"{alterPrefix} {someString}"));
        }
    }
}