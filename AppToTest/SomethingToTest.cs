using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppToTest
{
    public class SomethingToTest : ISomethingToTest
    {
        public bool ReturnTrue()
        {
            return true;
        }
        public bool ReturnFalse()
        {
            return false;
        }
        public string GiveItBackToMe(string it)
        {
            return it;
        }

        public void SomethingToBeCalled(string it)
        {
            throw new NotImplementedException();
        }

        public void SomethingToBeIgnored(string it)
        {
            throw new NotImplementedException();
        }

        public string GiveItBackToMeAltered(string it)
        {
            throw new NotImplementedException();
        }

        public int SomeNumberICareAbout { get; set; }
    }
}
