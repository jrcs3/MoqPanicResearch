namespace AppToTest
{
    public interface ISomethingToTest
    {
        int SomeNumberICareAbout { get; set; }

        string GiveItBackToMe(string it);
        bool ReturnFalse();
        bool ReturnTrue();

        void SomethingToBeCalled(string it);
        void SomethingToBeIgnored(string it);
    }
}