using Moq;

namespace AppToTest.Moq
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
            //int actualSomeNumberICareAbout = 0;

            var SomethingToTestMock = new Mock<ISomethingToTest>();
            SomethingToTestMock.Setup(x => x.GiveItBackToMe(someString)).Returns(someString);
            SomethingToTestMock.Setup(x => x.ReturnTrue()).Returns(true);
            SomethingToTestMock.Setup(x => x.ReturnFalse()).Returns(false);

            SomethingToTestMock.SetupSet(x => x.SomeNumberICareAbout = someNumberICareAbout).Verifiable();
            SomethingToTestMock.SetupGet(x => x.SomeNumberICareAbout).Returns(someNumberICareAbout);

            SomethingToTestMock.Object.SomeNumberICareAbout = someNumberICareAbout;
            SomethingToTestMock.Object.SomethingToBeCalled(someString);

            Assert.That(SomethingToTestMock.Object.GiveItBackToMe(someString), Is.EqualTo(someString));
            Assert.That(SomethingToTestMock.Object.ReturnTrue(), Is.True);
            Assert.That(SomethingToTestMock.Object.ReturnFalse(), Is.False);
            Assert.That(SomethingToTestMock.Object.SomeNumberICareAbout, Is.EqualTo(someNumberICareAbout));
            SomethingToTestMock.Verify(x => x.SomethingToBeCalled(someString), Times.Once);
            SomethingToTestMock.Verify(x => x.SomethingToBeIgnored(It.IsAny<string>()), Times.Never);

            //Assert.That(actualSomeNumberICareAbout, Is.EqualTo(someNumberICareAbout));
        }
    }
}